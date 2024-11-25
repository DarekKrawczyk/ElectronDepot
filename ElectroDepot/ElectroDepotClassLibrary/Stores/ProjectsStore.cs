using Avalonia.Media.Imaging;
using ElectroDepotClassLibrary.DataProviders;
using ElectroDepotClassLibrary.Models;

namespace ElectroDepotClassLibrary.Stores
{
    public class ProjectsStore
    {
        private readonly ProjectDataProvider _projectDataProvider;
        private List<Project> _projects;

        public IEnumerable<Project> Projects { get { return _projects; } }
        public ProjectDataProvider DB { get { return _projectDataProvider; } }

        public event Action ProjectsLoaded;

        public ProjectsStore(ProjectDataProvider projectDataProvider)
        {
            _projectDataProvider = projectDataProvider;
            _projects = new List<Project>();
        }

        public async Task Load()
        {
            _projects.Clear();

            IEnumerable<Project> projectsFromDB = await _projectDataProvider.GetAllProjects();
            foreach(Project project in projectsFromDB)
            {
                Bitmap image = await _projectDataProvider.GetImageOfProjectByID(project);
                project.Image = image;
            }
            _projects.AddRange(projectsFromDB);

            ProjectsLoaded?.Invoke();
        }
    }
}
