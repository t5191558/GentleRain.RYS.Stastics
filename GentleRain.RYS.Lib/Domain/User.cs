using AutoMapper;
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
        private IPosition Position { get; set; }
        private ITax Tax { get; set; }
        private IUserRepository UserRepository { get; set; }
        private IMapper Mapper { get; set; }
        
        public User(IPosition position, ITax tax, IUserRepository userRepository, IMapper mapper)
        {
            Position = position;
            Tax = tax;
            UserRepository = userRepository;
            Mapper = mapper; 
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
            return Mapper.Map<UserModel>(this) ?? throw new UserNotFoundException(Name);
        }

        public void Update(UserUpdateModel user)
        {
            Code = user.Code;
            Name = user.Name;
            _position = Position.GetFromCode(user.PositionCode);
            _tax = Tax.GetFromCode(user.TaxCode ?? "");
            UserRepository.Update(this);
        }

        public void Delete(string code)
        {
            var user = UserRepository.GetByCodeAsync(code).Result;
            UserRepository.Remove(user ?? throw new UserNotFoundException(code));
        }

        public UserModel GetFromCode(string code)
        {
            var user = UserRepository.GetByCodeAsync(code).Result;
            return Mapper.Map<UserModel>(user) ?? throw new UserNotFoundException(code);
        }

        public UserModel GetFromName(string name)
        {
            var user = UserRepository.GetByNameAsync(name).Result;
            return Mapper.Map<UserModel>(user) ?? throw new UserNotFoundException(name);
        }

        public List<UserModel> GetFromPosition(string positionCode)
        {
            UserRepository.GetByPosition(positionCode);
            throw new NotImplementedException();
        }

        public List<UserModel> Gets()
        {
            var users = UserRepository.GetAllAsync().Result;
            return Mapper.Map<List<UserModel>>(users) ?? new List<UserModel>();
        }

        public TaxModel GetTax()
        {
            return _tax;
        }

        public PositionModel GetPosition()
        {
            return _position;
        }
    }
}
