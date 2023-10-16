using Realms;
public class SongInfo : RealmObject
{
    [PrimaryKey]
    public int ID {get; set;}
    [Required]
    public string Name {get; set;}
    public string Singer {get; set;}
    public string SongWriter {get; set;}
    public string LyricWriter {get; set;}
    public string Path {get; set;}
    public void SetAttribute(string field, string value) {
        typeof(SongInfo).GetField(field).SetValue(this, value);
    }
}