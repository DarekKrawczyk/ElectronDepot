using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectroDepotClassLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.ExtensionMethods;
using Server.Models;

namespace Server.Controllers
{
    [Route("ElectroDepot/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProjectsController(DatabaseContext context)
        {
            _context = context;
        }
        #region Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ProjectDTO>> CreateProject(CreateProjectDTO project)
        {
            Project newProject = project.ToProject();
            newProject.CreatedAt = DateTime.Now;

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectsOfUser), new { id = newProject.ProjectID }, newProject);
        }

        #endregion
        #region Read
        /// <summary>
        /// GET: ElectroDepot/Projects/GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            return await _context.Projects.Select(x=>x.ToProjectDTO()).ToListAsync();
        }

        /// <summary>
        /// GET: ElectroDepot/Projects/GetAllOfUser/{ID}
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetAllOfUser/{ID}")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsOfUser(int ID)
        {
            User? user = await _context.Users.FindAsync(ID);

            if (user == null)
            {
                return NotFound();
            }

            return await _context.Projects.Where(x=>x.UserID == ID).Select(x=>x.ToProjectDTO()).ToListAsync();
        }

        /// <summary>
        /// GET: ElectroDepot/Projects/GetProjectComponentByID/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectByID(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project.ToProjectDTO();
        }

        /// <summary>
        /// GET: ElectroDepot/Projects/GetAllComponentsFromProject/{ID}
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetAllComponentsFromProject/{ID}")]
        public async Task<ActionResult<IEnumerable<ComponentDTO>>> GetAllComponentsFromProject(int ID)
        {
            try
            {
                Project? project = await _context.Projects.FindAsync(ID);

                if (project == null)
                {
                    return NotFound();
                }
                IEnumerable<ComponentDTO> componentsFromProject = await (from projectComponents in _context.ProjectComponents
                                                                         join components in _context.Components
                                                                         on projectComponents.ComponentID equals components.ComponentID
                                                                         where projectComponents.ProjectID == ID
                                                                         select new ComponentDTO(
                                                                             components.ComponentID,
                                                                             components.CategoryID,
                                                                             components.Name,
                                                                             components.Manufacturer,
                                                                             components.Description)
                                                                       ).ToListAsync();
                return Ok(componentsFromProject);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDTO projectDTO)
        {
            Project? project = await _context.Projects.FindAsync(id);
            if(project == null)
            {
                return NotFound();
            }

            project.Name = projectDTO.Name;
            project.Description = projectDTO.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }
        #endregion
        #region Delete

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
