using System.Collections.ObjectModel;
using Model;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class ModelWindowViewModel
    {
        public ModelWindowViewModel(ModelGraph model)
        {
            Model = (ModelGraph)model.Clone();
            Name = Model.Name;
            Entities = new ObservableCollection<Entity>(Model.Entities);
            Relationships = new ObservableCollection<Relationship>(Model.Relationships);
            TransformationsModelText = new ObservableCollection<TransformationModelText>(Model.TransformationsModelText);
            TransformationsModelModel = new ObservableCollection<TransformationModelModel>(Model.TransformationsModelModel);
            AddEntityCommand = new DelegateCommand(AddEntity);
            DeleteEntityCommand = new DelegateCommand(DeleteEntity);
            DeleteRelationshipCommand = new DelegateCommand(DeleteRelationship);
            DeleteTransformationModelTextCommand = new DelegateCommand(DeleteTransformationModelText);
            DeleteTransformationModelModelCommand = new DelegateCommand(DeleteTransformationModelModel);
            SaveCommand = new DelegateCommand(Save);
        }

        #region Properties

        public ModelGraph Model { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Entity> Entities { get; set; }

        public ObservableCollection<Relationship> Relationships { get; set; }

        public ObservableCollection<TransformationModelText> TransformationsModelText { get; set; }

        public ObservableCollection<TransformationModelModel> TransformationsModelModel { get; set; }

        public Entity SelectedEntity { get; set; }

        public Relationship SelectedRelationship { get; set; }

        public TransformationModelText SelectedTransformationModelText { get; set; }

        public TransformationModelModel SelectedTransformationModelModel { get; set; }

        public bool? DialogResult { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddEntityCommand { get; set; }

        public DelegateCommand AddRelationshipCommand { get; set; }

        public DelegateCommand AddTransformationModelTextCommand { get; set; }

        public DelegateCommand AddTransformationModelModelCommand { get; set; }

        public DelegateCommand DeleteEntityCommand { get; set; }

        public DelegateCommand DeleteRelationshipCommand { get; set; }

        public DelegateCommand DeleteTransformationModelTextCommand { get; set; }

        public DelegateCommand DeleteTransformationModelModelCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion

        #region Methods

        private void DeleteEntity()
        {
            if (SelectedEntity == null) return;
            Entities.Remove(SelectedEntity);
        }

        private void DeleteRelationship()
        {
            if (SelectedRelationship == null) return;
            Relationships.Remove(SelectedRelationship);
        }

        private void DeleteTransformationModelText()
        {
            if (SelectedTransformationModelText == null) return;
            TransformationsModelText.Remove(SelectedTransformationModelText);
        }

        private void DeleteTransformationModelModel()
        {
            if (SelectedTransformationModelModel == null) return;
            TransformationsModelModel.Remove(SelectedTransformationModelModel);
        }

        private void AddEntity()
        {
            var entity = new Entity();
            var entityWindow = new EntityWindow(entity);
            var result = entityWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if(entityWindow.DataContext is EntityWindowViewModel vm)
                    Entities.Add(vm.Entity);
            }
        }

        private void Save()
        {
            Model.Name = Name;
            Model.Entities = Entities;
            Model.Relationships = Relationships;
            Model.TransformationsModelModel = TransformationsModelModel;
            Model.TransformationsModelText = TransformationsModelText;
            CloseCommand.Execute(null);
        }

        #endregion
    }
}