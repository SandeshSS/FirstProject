using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    internal class ClubCardRegManager : IClubCardRegManager
    {

        private IClubCardRegRepository repository;

        public ClubCardRegManager(IUnitOfWork uow)
        {
            repository = uow.GetClubCardRegRepository();
        }

        public void SaveClubCardReg(ClubCardReg clubcardreg)
        {
            repository.Create(clubcardreg);

        }

        public IList<ClubCardReg> GetClubCardRegs()
        {
            return repository.All().ToList<ClubCardReg>();
        }

        public IList<ClubCardReg> GetClubCardRegById(string ClubCardId)
        {
            return repository.Get(c => c.ClubCardRegId.Equals(ClubCardId)).ToList<ClubCardReg>();
        }

    }
}