using System.Collections.ObjectModel;
using System.Linq;
using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class ModelWindowViewModel : ViewModelBase
    {
        public ModelWindowViewModel(ModelGraph model)
        {
            Model = new ModelGraph{Id = model.Id, ModelGraphParent = model.ModelGraphParent, ModelGraphParent1 = model.ModelGraphParent1};
            Name = model.Name;
            Entities = new ObservableCollection<Entity>(model.Entities);
            Relationships = new ObservableCollection<Relationship>(model.Relationships);
            TransformationsModelText = new ObservableCollection<TransformationModelText>(model.TransformationsModelText);
            TransformationsModelModel = new ObservableCollection<TransformationModelModel>(model.TransformationsModelModel);
            AddEntityCommand = new DelegateCommand(AddEntity);
            AddRelationshipCommand = new DelegateCommand(AddRelationship);
            AddTransformationModelModelCommand = new DelegateCommand(AddTransformationModelModel);
            AddTransformationModelTextCommand = new DelegateCommand(AddTransformationModelText);
            DeleteEntityCommand = new DelegateCommand(DeleteEntity);
            DeleteRelationshipCommand = new DelegateCommand(DeleteRelationship);
            DeleteTransformationModelTextCommand = new DelegateCommand(DeleteTransformationModelText);
            DeleteTransformationModelModelCommand = new DelegateCommand(DeleteTransformationModelModel);
            EditEntityCommand = new DelegateCommand(EditEntity);
            EditRelationshipCommand = new DelegateCommand(EditRelationship);
            EditTransformationModelModelCommand = new DelegateCommand(EditTransformationModelModel);
            EditTransformationModelTextCommand = new DelegateCommand(EditTransformationModelText);
            SaveCommand = new DelegateCommand(Save);
        }

        #region Properties

        public bool IsValid => !string.IsNullOrEmpty(Name);

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

        public DelegateCommand EditEntityCommand { get; set; }

        public DelegateCommand EditRelationshipCommand { get; set; }

        public DelegateCommand EditTransformationModelTextCommand { get; set; }

        public DelegateCommand EditTransformationModelModelCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

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

        private void EditEntity()
        {
            if(SelectedEntity == null) return;
            var entityWindow = new EntityWindow(SelectedEntity);
            var result = entityWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (entityWindow.DataContext is EntityWindowViewModel vm)
                {
                    Entities.Insert(Entities.IndexOf(SelectedEntity), vm.Entity);
                    Entities.Remove(SelectedEntity);
                }
                    
            }
        }

        private void AddRelationship()
        {
            var relationship = new Relationship();
            var relationshipWindow = new RelationshipWindow(relationship, Entities);
            var result = relationshipWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (relationshipWindow.DataContext is RelationshipWindowViewModel vm)
                    Relationships.Add(vm.Relationship);
            }
        }

        private void EditRelationship()
        {
            if(SelectedRelationship == null) return;
            var relationshipWindow = new RelationshipWindow(SelectedRelationship, Entities);
            var result = relationshipWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (relationshipWindow.DataContext is RelationshipWindowViewModel vm)
                {
                    Relationships.Insert(Relationships.IndexOf(SelectedRelationship), vm.Relationship);
                    Relationships.Remove(SelectedRelationship);
                }
            }
        }

        private void AddTransformationModelModel()
        {
            var transformation = new TransformationModelModel();
            var transformationWindow = new TransformationModelModelWindow(transformation);
            var result = transformationWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (transformationWindow.DataContext is TransformationModelModelViewModel vm)
                {
                    TransformationsModelModel.Add(vm.TransformationModelModel);
                }
            }
        }

        private void EditTransformationModelModel()
        {
            if(SelectedTransformationModelModel==null)return;
            var transformationWindow = new TransformationModelModelWindow(SelectedTransformationModelModel);
            var result = transformationWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (transformationWindow.DataContext is TransformationModelModelViewModel vm)
                {
                    TransformationsModelModel.Insert(TransformationsModelModel.IndexOf(SelectedTransformationModelModel), vm.TransformationModelModel);
                    TransformationsModelModel.Remove(SelectedTransformationModelModel);
                }
            }
        }

        private void AddTransformationModelText()
        {
            var transformation = new TransformationModelText();
            var transformationWindow = new TransformationModelTextWindow(transformation);
            var result = transformationWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (transformationWindow.DataContext is TransformationModelTextViewModel vm)
                {
                    TransformationsModelText.Add(vm.TransformationModelText);
                }
            }
        }

        private void EditTransformationModelText()
        {
            if (SelectedTransformationModelText == null) return;
            var transformationWindow = new TransformationModelTextWindow(SelectedTransformationModelText);
            var result = transformationWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (transformationWindow.DataContext is TransformationModelTextViewModel vm)
                {
                    TransformationsModelText.Insert(TransformationsModelText.IndexOf(SelectedTransformationModelText), vm.TransformationModelText);
                    TransformationsModelText.Remove(SelectedTransformationModelText);
                }
            }
        }

        private void Save()
        {
            Model.Name = Name;
            Model.Entities = Entities;
            Model.Relationships = Relationships;
            Model.TransformationsModelModel = TransformationsModelModel;
            Model.TransformationsModelText = TransformationsModelText;
            SetDialogResultCommand.Execute(true);
            CloseCommand.Execute(null);
        }

        #endregion
    }
}