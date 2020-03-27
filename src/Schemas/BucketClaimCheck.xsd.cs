namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"https://developer.kramp.com/bucketclaimcheck/2020/03/26",@"BucketEntry")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Schemas.AccountId), XPath = @"/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='TargetInfo' and namespace-uri()='']/*[local-name()='AccountId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Schemas.AccountName), XPath = @"/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='TargetInfo' and namespace-uri()='']/*[local-name()='Name' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Schemas.StorageName), XPath = @"/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='ResourcSourceInfo' and namespace-uri()='']/*[local-name()='BucketName' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.PropertyAttribute(typeof(global::Schemas.ResourceName), XPath = @"/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='ResourcSourceInfo' and namespace-uri()='']/*[local-name()='ResourceName' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"BucketEntry"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.ClaimCheckProperties", typeof(global::Schemas.ClaimCheckProperties))]
    public sealed class BucketClaimCheck : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""https://developer.kramp.com/bucketclaimcheck/2020/03/26"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""https://developer.kramp.com/claimcheckproperties/2020/03/26"" targetNamespace=""https://developer.kramp.com/bucketclaimcheck/2020/03/26"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <b:imports>
        <b:namespace prefix=""ns0"" uri=""https://developer.kramp.com/claimcheckproperties/2020/03/26"" location=""Schemas.ClaimCheckProperties"" />
      </b:imports>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""BucketEntry"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property name=""ns0:AccountId"" xpath=""/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='TargetInfo' and namespace-uri()='']/*[local-name()='AccountId' and namespace-uri()='']"" />
          <b:property name=""ns0:Name"" xpath=""/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='TargetInfo' and namespace-uri()='']/*[local-name()='Name' and namespace-uri()='']"" />
          <b:property name=""ns0:StorageName"" xpath=""/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='ResourcSourceInfo' and namespace-uri()='']/*[local-name()='BucketName' and namespace-uri()='']"" />
          <b:property name=""ns0:ResourceName"" xpath=""/*[local-name()='BucketEntry' and namespace-uri()='https://developer.kramp.com/bucketclaimcheck/2020/03/26']/*[local-name()='ResourcSourceInfo' and namespace-uri()='']/*[local-name()='ResourceName' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""TargetInfo"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""AccountId"" type=""xs:string"" />
              <xs:element name=""Name"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name=""ResourcSourceInfo"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""BucketName"" type=""xs:string"" />
              <xs:element name=""ResourceName"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public BucketClaimCheck() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "BucketEntry";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
