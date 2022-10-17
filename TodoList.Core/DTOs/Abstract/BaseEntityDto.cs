namespace TodoList.Core.DTOs.Abstract
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}