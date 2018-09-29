using Domain.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public static class ExtensionMethodTypeConference
    {
        public static IEnumerable<SelectListItem> DropDownList(this IEnumerable<String> TS)
        {
            return TS.OrderBy(x => x)
                  .Select(x =>
                  new SelectListItem
                  {
                      Text = x,
                      Value = x.ToString()
                  });
        }

    }
}