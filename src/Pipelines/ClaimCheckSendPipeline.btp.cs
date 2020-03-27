namespace Pipelines
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class ClaimCheckSendPipeline : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemb"+
"le\" minOccurs=\"0\" maxOccurs=\"1\" execMethod=\"All\" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />  "+
"    <Components />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name="+
"\"Encode\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6"+
"\" />      <Components>        <Component>          <Name>PipelineComponents.ClaimCheckPipelineCompon"+
"ent,PipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null</Name>          <Compon"+
"entName>ClaimCheckPipelineComponent</ComponentName>          <Description>Claim Check Pipeline Compo"+
"nent</Description>          <Version>1.0</Version>          <Properties>            <Property Name=\""+
"Enabled\">              <Value xsi:type=\"xsd:boolean\">true</Value>            </Property>            "+
"<Property Name=\"ClientId\">              <Value xsi:type=\"xsd:string\">111382948100122064143</Value>  "+
"          </Property>            <Property Name=\"ServiceAccountName\">              <Value xsi:type=\""+
"xsd:string\">biztalkservice@vwprojectmanager-1492166909167.iam.gserviceaccount.com</Value>           "+
" </Property>            <Property Name=\"ServiceAccountKey\">              <Value xsi:type=\"xsd:string"+
"\">C:\\KRAMP\\BizTalk.ClaimCheck\\Tests\\Google-Credentials.json</Value>            </Property>          "+
"</Properties>          <CachedDisplayName>ClaimCheckPipelineComponent</CachedDisplayName>          <"+
"CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage>  </Stages>"+
"</Document>";
        
        private const string _versionDependentGuid = "b4cb940a-f80f-4464-a4c7-f853d21756c9";
        
        public ClaimCheckSendPipeline()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4108-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("PipelineComponents.ClaimCheckPipelineComponent,PipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"Enabled\">      "+
"<Value xsi:type=\"xsd:boolean\">true</Value>    </Property>    <Property Name=\"ClientId\">      <Value "+
"xsi:type=\"xsd:string\">111382948100122064143</Value>    </Property>    <Property Name=\"ServiceAccount"+
"Name\">      <Value xsi:type=\"xsd:string\">biztalkservice@vwprojectmanager-1492166909167.iam.gservicea"+
"ccount.com</Value>    </Property>    <Property Name=\"ServiceAccountKey\">      <Value xsi:type=\"xsd:s"+
"tring\">C:\\KRAMP\\BizTalk.ClaimCheck\\Tests\\Google-Credentials.json</Value>    </Property>  </Propertie"+
"s></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
