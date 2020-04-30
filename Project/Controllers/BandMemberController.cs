using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [Route("api/v1/BandMembers")]
    public class BandMemberController : Controller
    {
      private readonly MusicContext context;

    
        public BandMemberController(MusicContext context){
            this.context = context;
        }



    }
}
