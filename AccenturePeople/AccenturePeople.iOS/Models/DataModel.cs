using System;
namespace AccenturePeople.iOS.Models
{
    public class DataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public DataModel(string _name, string _description, string _image){
            this.Name = _name;
            this.Description = _description;
            this.Image = _image;
        }
    }
}
