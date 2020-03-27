using System;
using System.IO;
using System.Reflection;
using Microsoft.BizTalk.Component;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;
using PipelineComponents;
using Winterdom.BizTalk.PipelineTesting;


namespace Tests
{
    [TestClass]
    public class PipelineComponentTests
    {
        ReceivePipelineWrapper rcvpipeline;
        SendPipelineWrapper sndpipeline;
        string googlecredentials = @"Google-Credentials.json";


        [TestInitialize]
        public void Setup()
        { 
        
            rcvpipeline =  PipelineFactory.CreateEmptyReceivePipeline();
            XmlDasmComp xmlDasmComp = new XmlDasmComp();
            rcvpipeline.AddComponent(xmlDasmComp, PipelineStage.Disassemble);

            sndpipeline = PipelineFactory.CreateEmptySendPipeline();

            if (!File.Exists(googlecredentials))
             { 
            
            }
        }

        [TestMethod]
        public void TestGoogleBucket()
        {


            IBaseMessage msg = MessageHelper.CreateFromString(Resource.GoogleBucketEntry_1);

            rcvpipeline.AddDocSpec(typeof(Schemas.BucketClaimCheck));
           
          

         MessageCollection messages =   rcvpipeline.Execute(msg);

            IBaseMessage message = messages[0];


            


            ClaimCheckPipelineComponent claimCheckPipelineComponent = new ClaimCheckPipelineComponent();

            claimCheckPipelineComponent.Enabled = true;
            claimCheckPipelineComponent.ClientId = "111382948100122064143";
            claimCheckPipelineComponent.ServiceAccountName = "biztalkservice@vwprojectmanager-1492166909167.iam.gserviceaccount.com";
            FileInfo credentials = new FileInfo(googlecredentials);
            var jsonfilepath = credentials.FullName;
            claimCheckPipelineComponent.ServiceAccountKey = jsonfilepath;
          


            sndpipeline.AddComponent(claimCheckPipelineComponent, PipelineStage.Encode);

           IBaseMessage sendmessage = sndpipeline.Execute(messages);

         


                Diff myDiff = DiffBuilder.Compare(Input.FromString(Resource.GoogleBucketResult))
              .WithTest(Input.FromStream(sendmessage.BodyPart.Data))
              .CheckForIdentical().Build();


            Assert.IsFalse(myDiff.HasDifferences());
           

            

        }


        [TestMethod]
        public void TestPipeline()
        {


            IBaseMessage msg = MessageHelper.CreateFromString(Resource.GoogleBucketEntry_1);

            rcvpipeline.AddDocSpec(typeof(Schemas.BucketClaimCheck));



            MessageCollection messages = rcvpipeline.Execute(msg);

            IBaseMessage message = messages[0];





            SendPipelineWrapper snddirectpipeline = PipelineFactory.CreateSendPipeline(typeof(Pipelines.ClaimCheckSendPipeline));



           

            IBaseMessage sendmessage = snddirectpipeline.Execute(messages);




            Diff myDiff = DiffBuilder.Compare(Input.FromString(Resource.GoogleBucketResult))
          .WithTest(Input.FromStream(sendmessage.BodyPart.Data))
          .CheckForIdentical().Build();


            Assert.IsFalse(myDiff.HasDifferences());




        }
    }
}
