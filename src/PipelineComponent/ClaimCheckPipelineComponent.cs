using System;
using System.Resources;
using System.Drawing;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Text;
using System.IO;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.XLANGs.BaseTypes;

using Microsoft.BizTalk.Streaming;
using System.Threading.Tasks;

namespace PipelineComponents
{

    /// <summary>
    /// Implements custom send pipeline component for  Claim Check Pattern.
    /// </summary>
    /// <remarks>
    /// ClaimCheckPipelineComponent class implements pipeline component that can be used in receive and
    /// send BizTalk pipelines. The pipeline component implements the  Claim Check Pattern.
    ///</remarks>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    ///[ComponentCategory(CategoryTypes.CATID_Decoder)]
    [ComponentCategory(CategoryTypes.CATID_Encoder)]
    [System.Runtime.InteropServices.Guid("9C2F7959-D3D8-4E79-9A22-93FD0F1BBFA7")]
    public class ClaimCheckPipelineComponent: IBaseComponent,
        Microsoft.BizTalk.Component.Interop.IComponent,
        IPersistPropertyBag,
        IComponentUI
    {

        private const string  nsclaimcheckproperties = "https://developer.kramp.com/claimcheckproperties/2020/03/26";
        private const string nsbtssystemproperties = "http://schemas.microsoft.com/BizTalk/2003/system-properties";

        private const string googlebucketmessagetype = "https://developer.kramp.com/bucketclaimcheck/2020/03/26#BucketEntry";
        private const string azuremessagetype = "https://developer.kramp.com/azureclaimcheck/2020/03/26#AzureEntry";
        private const string filemessagetype = "https://developer.kramp.com/fileclaimcheck/2020/03/26#FileEntry";

        private bool _Enabled;
        private string _ClientId;
         private string _ServiceAccountName;
        
        private string _ServiceAccountKey;
        private string _messagetype;

        private string  _accountId { get; set; }
        private string _name { get; set; }
        private string _storageName { get; set; }
        private string _resourceName { get; set; }




        static ResourceManager resManager = new ResourceManager("PipelineComponents.ClaimCheckPipelineComponent", Assembly.GetExecutingAssembly());

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            if (Enabled == false)
            {
                return pInMsg;
            }

            if (null == pContext)
                throw new ArgumentNullException("PC is null");
            if (null == pInMsg)
                throw new ArgumentNullException("pInMsg is null");

            IBaseMessageContext messageContext = pInMsg.Context;

            // Get by messagetype
            _messagetype = pInMsg.Context.Read("MessageType", nsbtssystemproperties) as string;
           

            if (pInMsg.BodyPart == null)
            {
                return pInMsg;
            }
            IBaseMessagePart bodyPart = pInMsg.BodyPart;

            string pipelineType = DetermingSendOrReceive(pContext);

            if (pipelineType.StartsWith("Unknown"))
            {
                throw new ApplicationException(pipelineType);
            }

            if (pipelineType == "Receive")  //Is primary SEND Pipeline Encode Component
            {

                return pInMsg;
            }


            IBaseMessage msg = ProcessSendPipeline(pInMsg, pContext);

            return msg;

        }

        private IBaseMessage ProcessSendPipeline(IBaseMessage pInMsg, IPipelineContext pContext)
        {

            GetMessageProperties(pInMsg);

            string type = string.Empty;

            switch (_messagetype)
            {
                case googlebucketmessagetype:
                    type = "bucket";
                    break;
                case azuremessagetype:
                    type = "azure";
                    break;
                case filemessagetype:
                    type = "file";
                    break;
                default:
                    break;
            }


            if (type == "file")
            {
                return ProcessFileClaimCheck(type, pInMsg, pContext);
            
            }
            if (type == "azure")
            {
                return ProcessAzureClaimCheck(type, pInMsg, pContext);

            }
            if (type == "bucket")
            {
                return ProcessGoogleClaimCheckAsync(type, pInMsg, pContext);

            }


            return pInMsg;
        }

        private IBaseMessage ProcessGoogleClaimCheckAsync(string type, IBaseMessage pInMsg, IPipelineContext pContext)
        {
            Stream objectstream = new VirtualStream(); /// use virtaulstream cause source can be large!!!

            objectstream = GoogleButcketHelper.DownloadObjectAsync(_storageName, _resourceName, _name, ServiceAccountName, ServiceAccountKey, ClientId,  objectstream).Result;


            objectstream.Position = 0;
            pContext.ResourceTracker.AddResource(objectstream);
            pInMsg.BodyPart.Data = objectstream;


            return pInMsg;


        }

        private IBaseMessage ProcessAzureClaimCheck(string type, IBaseMessage pInMsg, IPipelineContext pContext)
        {
            return pInMsg;
        }

        private IBaseMessage ProcessFileClaimCheck(string type, IBaseMessage pInMsg, IPipelineContext pContext)
        {
            return pInMsg;
        }








        #region Properties

        [
        ClaimCheckPipelineComponentPropertyName("PropEnabled"),
        ClaimCheckPipelineComponentDescription("DescrEnabled"),
        DefaultValue(true)
        ]
        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        [
        ClaimCheckPipelineComponentPropertyName("PropClientId"),
        ClaimCheckPipelineComponentDescription("DescrClientId")
        ]
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }

        

        [
        ClaimCheckPipelineComponentPropertyName("PropServiceAccountName"),
        ClaimCheckPipelineComponentDescription("DescrServiceAccountName")
        ]
        public string ServiceAccountName
        {
            get { return _ServiceAccountName; }
            set { _ServiceAccountName = value; }
        }

       

        [
        ClaimCheckPipelineComponentPropertyName("PropServiceAccountKey"),
        ClaimCheckPipelineComponentDescription("DescrServiceAccountKey")
        ]
        public string ServiceAccountKey
        {
            get { return _ServiceAccountKey; }
            set { _ServiceAccountKey = value; }
        }

        #endregion

        #region IPersistPropertyBag


        public void GetClassID(out Guid classid)
        {
            classid = new System.Guid("9C2F7959-D3D8-4E79-9A22-93FD0F1BBFA7");
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void InitNew()
        {
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            object val = null;
            val = ReadPropertyBag(propertyBag, "Enabled");
            if ((val != null))
            {
                this._Enabled = ((bool)(val));
            }
            else
            {
                this._Enabled = true;
            }
            val = ReadPropertyBag(propertyBag, "ClientId");
            if ((val != null))
            {
                this._ClientId = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "ServiceAccountName");
            if ((val != null))
            {
                this._ServiceAccountName = ((string)(val));
            }
          
          
            val = ReadPropertyBag(propertyBag, "ServiceAccountKey");
            if ((val != null))
            {
                this._ServiceAccountKey = ((string)(val));
            }
           
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            WritePropertyBag(propertyBag, "Enabled", this.Enabled);
            WritePropertyBag(propertyBag, "ClientId", this.ClientId);
          
            WritePropertyBag(propertyBag, "ServiceAccountName", this.ServiceAccountName);
            WritePropertyBag(propertyBag, "ServiceAccountKey", this.ServiceAccountKey);
            
        }



        #endregion

        #region IBaseComponent
        /// <summary>
        /// Name of the component.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get { return "ClaimCheckPipelineComponent"; }
        }

        /// <summary>
        /// Version of the component.
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get { return "1.0"; }
        }

        /// <summary>
        /// Description of the component.
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get { return "Claim Check Pipeline Component"; }
        }


        #endregion

        #region IComponentUi
        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">Project system.</param>
        /// <returns>
        /// A list of error and/or warning messages encounter during validation
        /// of this component.
        /// </returns>
        public IEnumerator Validate(object obj)
        {
            IEnumerator enumerator = null;
            ArrayList strList = new ArrayList();

            // Validate prepend data property
            //if ((prependData != null) &&
            //(prependData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorPrependDataTooLong"));
            //}

            // validate append data property
            //if ((appendData != null) &&
            //(appendData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorAppendDataTooLong"));
            //}

            if (strList.Count > 0)
            {
                enumerator = strList.GetEnumerator();
            }

            return enumerator;
        }

        /// <summary>
        /// Component icon to use in BizTalk Editor.
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return ((Bitmap)resManager.GetObject("ClaimCheckPipelineComponentBitmap")).GetHicon();
            }

        }
    #endregion




    #region Privates

    /// <summary>
    /// Get ClaimCheckProperties from the Message Context
    /// </summary>
    /// <param name="pInMsg">InboundMessage</param>
    private void GetMessageProperties(IBaseMessage pInMsg)
    {
            _accountId = pInMsg.Context.Read("AccountID", nsclaimcheckproperties) as string;
            _name = pInMsg.Context.Read("Name", nsclaimcheckproperties) as string;
            _storageName = pInMsg.Context.Read("StorageName", nsclaimcheckproperties) as string;
            _resourceName = pInMsg.Context.Read("ResourceName", nsclaimcheckproperties) as string;

     }


    /// <summary>
    /// Reads property value from property bag.
    /// </summary>
    /// <param name="pb">Property bag.</param>
    /// <param name="propName">Name of property.</param>
    /// <returns>Value of the property.</returns>
    private static object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }

            catch (ArgumentException)
            {
                return val;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return val;
        }

        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private static void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private static string DetermingSendOrReceive(IPipelineContext pContext)
        {
            // send or receive 
            string pipelineType = "";
            switch (pContext.StageID.ToString())
            {
                case CategoryTypes.CATID_Decoder: 
                case CategoryTypes.CATID_DisassemblingParser:
                case CategoryTypes.CATID_Validate:
                case CategoryTypes.CATID_PartyResolver:
                    pipelineType = "Receive";
                    break;
                case CategoryTypes.CATID_Encoder: // should only be here on send
                case CategoryTypes.CATID_Transmitter:
                case CategoryTypes.CATID_AssemblingSerializer:
                    pipelineType = "Send";
                    break;
                default:
                    pipelineType = "Unknown Pipeline Stage - " + pContext.StageID.ToString();
                    break;
            }

            return pipelineType;
        }

        #endregion

    }
}
