namespace SchoolAPI.Data.Dto.Grades;

public class ReadGradesByStudentIdDto
{
    public int Id { get; set; }
    public float Grades1 { get; set; }
    public float Grades2 { get; set; }
    public float Grades3 { get; set; }
    public float Grades4 { get; set; }
    public float Gpa { get; set; }
    public string Status { get; set; }
    public string StudentName { get; set; }
    public string MatterName { get; set; }  
}
