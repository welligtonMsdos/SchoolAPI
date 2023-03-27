namespace SchoolAPI.Data.Model;

public class Professor: Person
{
    public Professor(int id, string name, bool active) : base(id, name, active)
    {   
    }

    public ICollection<MatterProfessor> matterProfessors { get; set; }
}
