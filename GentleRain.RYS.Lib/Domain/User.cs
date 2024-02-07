using GentleRain.RYS.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GentleRain.RYS.Lib
{
    public class User : BaseEntity, IUser
    {
        public string Name { get; set; } = string.Empty;
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }
        private TaxModel _tax = new TaxModel();
        private PositionModel _position = new PositionModel();
        public IPosition Position { get; set; }
        public ITax Tax { get; set; }
        public IUserRepository UserRepository { get; set; }
        public User(IUserRepository repository)
        {
            Position = new Position();
            Tax = new Tax();
            UserRepository = repository;
        }
        public User(IPosition position, ITax tax, IUserRepository userRepository)
        {
            Position = position;
            Tax = tax;
            UserRepository = userRepository;
        }

        private void ExistsByName(string name) 
        {
            User olduser = UserRepository.GetByNameAsync(name).Result;
            if (olduser == this)
                throw new UserSameNameException(name);
        }

        public UserModel Create(UserCreateModel user)
        {
            if(!string.IsNullOrWhiteSpace(user.TaxCode))
            {
                _tax = Tax.GetFromCode(user.TaxCode);
            }
            _position = Position.GetFromCode(user.PositionCode);
            ExistsByName(user.Name);
            var uuser = UserRepository.AddAsync(this).Result;
            this.Code = uuser.Code;

            return new UserModel();
        }

        public void Update(UserUpdateModel user)
        {
            throw new NotImplementedException();
        }

        public void Delete(string code)
        {
            throw new NotImplementedException();
        }

        public UserModel GetFromCode(string code)
        {
            throw new NotImplementedException();
        }

        public UserModel GetFromName(string name)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetFromPosition(string positionCode)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> Gets()
        {
            throw new NotImplementedException();
        }
    }
}
