using System.Collections.ObjectModel;
using System.Windows;
using Model;
using WPFMVVMLib.Commands;
using WPFMVVMLib;
//using Model;

namespace Course2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Models = new ObservableCollection<ModelGraph>();
            LoadModelsCommand = new DelegateCommand(LoadModels);
            CreateNewModelCommand = new DelegateCommand(CreateNewModel);
        }

        public ObservableCollection<ModelGraph> Models { get; set; }

        public DelegateCommand LoadModelsCommand { get; set; }

        public DelegateCommand CreateNewModelCommand { get; set; }

        public void LoadModels()
        {
            using (var db = new VmaContainer())
            {
                var models = db.ModelGraphSet;
                foreach (var modelGraph in models)
                {
                    Models.Add(modelGraph);
                }
            }
        }

        public void CreateNewModel()
        {
            //var entity1 = new Entity() { Name = "some entity" };
            //var entity2 = new Entity() { Name = "second entity" };
            //var relationship = new Relationship() { Entity1 = entity1, Entity2 = entity2, Name = "some relationship" };
            //var model = new ModelGraph() { Name = "BLABLABLA MODEL FIRST", Entities = new[] { entity1, entity2 }, Relationships = new[] { relationship } };
            //var modelWindow = new ModelWindow(model);
            //var result = modelWindow.ShowDialog();

            //if (modelWindow.DataContext is ModelWindowViewModel vm)
            //{
            //    model = vm.Model;
            //}
            //MessageBox.Show(model.Name + model.Entities.Count);
        }
    }
}

    
