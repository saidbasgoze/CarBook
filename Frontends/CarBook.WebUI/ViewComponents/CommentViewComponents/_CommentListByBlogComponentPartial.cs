using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.NewFolder
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
