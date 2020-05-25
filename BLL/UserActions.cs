using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BLL
{
    public class UserActions
    {
        IMapper UsersM = new MapperConfiguration(cfg => cfg.CreateMap<User, MUser>()).CreateMapper();
        private readonly UnitOfWork uow;

        public UserActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserActions()
        {
            Context context = new Context();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));
        }


        public virtual List<MUser> GetUsers()
        {
            return UsersM.Map<IEnumerable<User>, List<MUser>>(uow.Users.Get());
        }

        public virtual MUser GetUserById(int id)
        {
            return UsersM.Map<User, MUser>(uow.Users.GetOne(x => (x.UserID == id)));
        }

        public virtual bool AddUser(MUser n)
        {
            uow.Users.Create(new User { Name = n.Name, Surname = n.Surname, RoleId = n.RoleId, Login = n.Login, Pass = n.Pass});
            uow.Save();
            return true;
        }

        public virtual bool DeleteUserByID(int id)
        {
            uow.Users.Remove(uow.Users.FindById(id));
            uow.Save();
            return true;
        }
    }
}
