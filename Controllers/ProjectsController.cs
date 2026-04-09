using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MzansiBuilds.Data;
using MzansiBuilds.Models;

namespace MzansiBuilds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.ProjectId = DataStore.Projects.Count;
            DataStore.Projects.Add(project);

            return Ok(project);
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(DataStore.Projects);
        }

        [HttpPost("{id}/comment")]
        public IActionResult AddComment(int id, [FromBody] string comment)
        {
            var project = DataStore.Projects.Find(p => p.ProjectId == id);

            if (project == null)
                return NotFound();

            project.Comments.Add(comment);

            return Ok(project);
        }

        [HttpPost("{id}/milestone")]
        public IActionResult AddMilestone(int id, [FromBody] string milestone)
        {
            var project = DataStore.Projects.Find(p => p.ProjectId == id);
            if (project == null)
                return NotFound();

            project.Milestones.Add(milestone);

            return Ok(project);
        }

        [HttpPost("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = DataStore.Projects.Find(p => p.ProjectId == id);

            project.Status = "completed";

            return Ok(project);
        }

        [HttpGet("celebration")]
        public IActionResult Celebration()
        {
            var completed = DataStore.Projects
                .FindAll(p => p.Status == "completed");

            return Ok(completed);
        }

    }
}
