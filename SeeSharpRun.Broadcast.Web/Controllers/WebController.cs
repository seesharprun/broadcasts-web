using SeeSharpRun.Broadcast.Data;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace SeeSharpRun.Broadcast.Web.Controllers
{
    [OutputCache(Duration = 86400)]
    public class WebController : Controller
    {
        BroadcastContext _context;
        
        public WebController(BroadcastContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> List()
        {
            return View(
                await _context.Broadcasts
                    .Where(b => b.IsPublic && b.LiveDateTime > DateTimeOffset.UtcNow)
                    .OrderBy(b => b.LiveDateTime)
                    .ToListAsync()
            );
        }

        public async Task<ActionResult> Link(string slug)
        {
            if (String.IsNullOrEmpty(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var broadcast = await _context.Broadcasts.SingleOrDefaultAsync(b => b.SemanticUrl == slug);
            if (broadcast == null)
            {
                return HttpNotFound();
            }
            else
            {
                return RedirectPermanent(broadcast.ViewLink);
            }
        }
        public async Task<ActionResult> Download(string slug)
        {
            if (String.IsNullOrEmpty(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var broadcast = await _context.Broadcasts.SingleOrDefaultAsync(b => b.SemanticUrl == slug);
            if (broadcast == null)
            {
                return HttpNotFound();
            }
            else
            {
                return RedirectPermanent(broadcast.VideoDownloadUrl);
            }
        }
    }
}