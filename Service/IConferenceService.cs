using Domain.Entities;
using Services.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
 public    interface IConferenceService: IService<Conference>
    {

        IEnumerable<Conference> getAll();
        int confJan();
        int confFev();
        int confMar();
        int confAvr();
        int confMai();
        int confJun();
        int confJul();
        int confAout();
        int confSep();
        int confOct();
        int confNov();
        int confDec();
        //OBLigatoire-Facultative
        int confFac();
        int confOblg();
    }
}
