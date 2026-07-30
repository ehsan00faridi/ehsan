namespace Domain.BaseEntity
{
    public interface IBaseEntity<K> where K : IEquatable<K>
    {
        public K Id { get;  set; }
        public DateTime Created { get; set; }
        public int? CreatedBy {  get; set; }
        public DateTime Modified {  get; set; }
        public int?  ModifiedBy { get; set; }
        public bool Enable {  get; set; }
       
    }
}