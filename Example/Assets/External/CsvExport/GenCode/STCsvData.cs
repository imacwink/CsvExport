//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: GenCode/STRes.proto
namespace STCsv
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EntityItem")]
  public partial class EntityItem : global::ProtoBuf.IExtensible
  {
    public EntityItem() {}
    
    private int _mID = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"mID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int mID
    {
      get { return _mID; }
      set { _mID = value; }
    }
    private string _mName = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"mName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mName
    {
      get { return _mName; }
      set { _mName = value; }
    }
    private string _mDesc = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"mDesc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mDesc
    {
      get { return _mDesc; }
      set { _mDesc = value; }
    }
    private float _mSpeed = default(float);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"mSpeed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float mSpeed
    {
      get { return _mSpeed; }
      set { _mSpeed = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Entity")]
  public partial class Entity : global::ProtoBuf.IExtensible
  {
    public Entity() {}
    
    private readonly global::System.Collections.Generic.List<STCsv.EntityItem> _mSzDataList = new global::System.Collections.Generic.List<STCsv.EntityItem>();
    [global::ProtoBuf.ProtoMember(1, Name=@"mSzDataList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<STCsv.EntityItem> mSzDataList
    {
      get { return _mSzDataList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}