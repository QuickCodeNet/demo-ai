using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickCode.Template0.Portal.Models;

namespace QuickCode.Template0.Portal.ViewComponents
{
    public class TextArea : ViewComponent
    {

        public TextArea()
        {

        }

        public IViewComponentResult Invoke(TextAreaData model)
        {
            return View(model);
        }

    }


}
