using Data.Infrastructure;
using Domain.Entities;
using Services.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ConferenceService: Service<Conference>, IConferenceService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public ConferenceService():base(ut)
        {

        }

        public IEnumerable<Conference> getAll()
        {
            return ut.getRepository<Conference>().GetMany(x => x.idConference != null);
        }

        /******************************STATS****************************/
        public int confJan()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 1).Count();
        }
        public int confFev()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 2).Count();
        }
        public int confMar()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 3).Count();
        }
        public int confAvr()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 4).Count();
        }
        public int confMai()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 5).Count();
        }
        public int confJun()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 6).Count();
        }
        public int confJul()
        {
            return ut.getRepository<Conference>().GetMany( x => x.dateConference.Month == 7).Count();
        }
        public int confAout()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 8).Count();
        }
        public int confSep()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 9).Count();
        }
        public int confOct()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 10).Count();
        }
        public int confNov()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 11).Count();
        }
        public int confDec()
        {
            return ut.getRepository<Conference>().GetMany(x => x.dateConference.Month == 12).Count();
        }
        /**********************************************************************************************/
        public int confFac()
        {
            return ut.getRepository<Conference>().GetMany(x => x.typeConference == type.Facultative).Count();
        }
        public int confOblg()
        {
            return ut.getRepository<Conference>().GetMany(x => x.typeConference == type.Obligatoire).Count();
        }
        /*********************************************************************************/
 
    }
}
