using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Landlord_project.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
