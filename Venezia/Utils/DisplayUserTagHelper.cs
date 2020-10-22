using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Venezia.Models;

namespace Venezia.Utils
{




    public class DisplayUserTagHelper : TagHelper
    {

        private readonly UserManager<User> _userManager;
        private readonly IActionContextAccessor _accessor;

        public DisplayUserTagHelper(UserManager<User> userManager, IActionContextAccessor accessor)
        {
            _userManager = userManager;
            _accessor = accessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var user = _accessor.ActionContext.HttpContext.User;
            var uid = _userManager.GetUserId(user);
            var name = _userManager.FindByIdAsync(uid).Result.Firstname;
            output.PreContent.SetHtmlContent("<strong>");
            output.Content.SetContent(name);
            output.PostContent.SetHtmlContent("</strong>");

        }

    }
}
