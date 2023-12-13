using BusinessAdvanceManagement.Core.Helpers.CRUDHelper;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.DataAccess.Interface;
using BusinessAdvanceManagement.Domain.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.DataAccess.Concrete
{
    public class WorkerDAL : IWorkerDAL
    {
        private readonly CRUDHelper _crudHelper;

        public WorkerDAL(CRUDHelper crudHelper)
        {
            _crudHelper = crudHelper;
        }

        public GeneralReturnType<WorkerAddDTO> Add(WorkerAddUserDTO workerAddUserDTO)
        {
            byte[] passwordHash, passwordSalt;
            PasswordGenerate(workerAddUserDTO.Password,out passwordHash,out passwordSalt);
            workerAddUserDTO.WorkerAddDTO.WorkerPasswordHash = passwordHash;
            workerAddUserDTO.WorkerAddDTO.WorkerPasswordSalt = passwordSalt;

            var query = "insert into Worker(WorkerRolID,WorkerManagerID,WorkerBirimID,WorkerName,WorkerSurname,WorkerEmail,WorkerPasswordHash,WorkerPasswordSalt) values (@workerRolID,@workerManagerID,@workerBirimID,@workerName,@workerSurname,@workerEmail,@workerPasswordHash,@workerPasswordSalt)";

            var parametre = new { workerRolID = workerAddUserDTO.WorkerAddDTO.WorkerRolID, workerManagerID = workerAddUserDTO.WorkerAddDTO.WorkerManagerID, workerBirimID = workerAddUserDTO.WorkerAddDTO.WorkerBirimID, workerName = workerAddUserDTO.WorkerAddDTO.WorkerName, workerSurname = workerAddUserDTO.WorkerAddDTO.WorkerSurname, workerEmail = workerAddUserDTO.WorkerAddDTO.WorkerEmail, workerPasswordHash = workerAddUserDTO.WorkerAddDTO.WorkerPasswordHash, workerPasswordSalt = workerAddUserDTO.WorkerAddDTO.WorkerPasswordSalt };

            return _crudHelper.ExecuteNonQuery<WorkerAddDTO>(query,parametre,new WorkerAddDTO());
        }

        private void PasswordGenerate(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        public GeneralReturnType<IEnumerable<WorkerListDTO>> GetAll()
        {
            var query = "select W.WorkerID,W.WorkerName,W.WorkerSurname,W.WorkerManagerID,W.WorkerBirimID,W.WorkerRolID,W.WorkerEmail,W.WorkerPasswordHash,W.WorkerPasswordSalt,R.RoleName,U.UnitName,WO.WorkerName,WO.WorkerSurname from Worker W join Role R on  W.WorkerRolID = R.RoleID join Unit U on W.WorkerBirimID = U.UnitID join Worker WO on WO.WorkerManagerID = W.WorkerID" ;

           return  _crudHelper.ExecuteQuery<WorkerListDTO>(query,"");
        }

        public WorkerListDTO Login(WorkerLoginDTO workerLoginDTO)
        {
            var result = IsWorker(workerLoginDTO);
            if (result == null)
            {
                return null;
            }
            if (!PasswordCheck(workerLoginDTO, result.WorkerPasswordHash, result.WorkerPasswordSalt))
            {
                return null;
            }
            return result;
        }

        private bool PasswordCheck(WorkerLoginDTO workerLoginDTO, byte[] workerPasswordHash, byte[] workerPasswordSalt)
        {
            using (var hmac = new HMACSHA512(workerPasswordSalt))
            {
                var _passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(workerLoginDTO.Password));
                for (int i = 0; i < _passwordHash.Length; i++)
                {
                    if (workerPasswordHash[i] != _passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private WorkerListDTO IsWorker(WorkerLoginDTO workerLoginDTO)
        {
            var query = "select W.WorkerID,W.WorkerName,W.WorkerSurname,W.WorkerManagerID,W.WorkerBirimID,W.WorkerRolID,W.WorkerEmail,W.WorkerPasswordHash,W.WorkerPasswordSalt,R.RoleName,U.UnitName from Worker W join Role R on  W.WorkerRolID = R.RoleID join Unit U on W.WorkerBirimID = U.UnitID  where W.WorkerEmail=@email";
            var parametre = new { email = workerLoginDTO.Email };

            var result= _crudHelper.ExecuteQuery<WorkerListDTO>(query,parametre).Datas.FirstOrDefault();
            return result;
        }
    }
}
