using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.USerDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }


        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IResult EditProfile(UserForUpdateDto user)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var userInfo = new User()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true
            };
            _userDal.Update(userInfo);
            return new SuccessResult();
        }
    }
}
