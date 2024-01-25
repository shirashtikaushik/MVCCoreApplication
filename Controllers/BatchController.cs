using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApplication.Controllers
{
    public class BatchController : Controller
    {
        private static List<string> batches = new List<string>();

        public IActionResult Index()
        {
            return View(batches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string batch)
        {
            if (ModelState.IsValid)
            {
               
                if (batches.Contains(batch))
                {
                    ModelState.AddModelError("Batch", "Batch must be unique");
                    return View(batch);
                }

                batches.Add(batch);
                return RedirectToAction("Index");
            }

            return View(batch);
        }

        public IActionResult Edit(string batch)
        {
            if (!batches.Contains(batch))
            {
                return NotFound();
            }

            return View(batch);
        }

        [HttpPost]
        public IActionResult Edit(string oldBatch, string newBatch)
        {
            if (ModelState.IsValid)
            {
                // Check for duplicate batch
                if (batches.Contains(newBatch) && newBatch != oldBatch)
                {
                    ModelState.AddModelError("Batch", "Batch must be unique");
                    return View(newBatch);
                }

                // Update batch
                batches.Remove(oldBatch);
                batches.Add(newBatch);
                return RedirectToAction("Index");
            }

            return View(newBatch);
        }

        public IActionResult Delete(string batch)
        {
            if (!batches.Contains(batch))
            {
                return NotFound();
            }

            return View(batch);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string batch)
        {
            batches.Remove(batch);
            return RedirectToAction("Index");
        }
    }

}
