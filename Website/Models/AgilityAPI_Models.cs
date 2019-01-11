using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agility.Web;
using Agility.Web.Objects;

namespace Website.AgilityModels
{
	public partial class AgilityCodeTemplate : Agility.Web.AgilityContentItem
	{
		private string __title = null;
		private bool __title_set = false;
		public virtual string Title { get { if (!__title_set) __title = GetFieldValue<string>("Title"); __title_set = true; return __title; } set { __title = value; __title_set = true;  } }
		private string __textblob = null;
		private bool __textblob_set = false;
		public virtual string TextBlob { get { if (!__textblob_set) __textblob = GetFieldValue<string>("TextBlob"); __textblob_set = true; return __textblob; } set { __textblob = value; __textblob_set = true;  } }
		private string __referencename = null;
		private bool __referencename_set = false;
		public virtual string ReferenceName { get { if (!__referencename_set) __referencename = GetFieldValue<string>("ReferenceName"); __referencename_set = true; return __referencename; } set { __referencename = value; __referencename_set = true;  } }
		private bool __visible;
		private bool __visible_set = false;
		public virtual bool Visible { get { if (!__visible_set) __visible = GetFieldValue<bool>("Visible"); __visible_set = true; return __visible; } set { __visible = value; __visible_set = true;  } }

	}
	public partial class AgilityCSS : Agility.Web.AgilityContentItem
	{
		private string __title = null;
		private bool __title_set = false;
		public virtual string Title { get { if (!__title_set) __title = GetFieldValue<string>("Title"); __title_set = true; return __title; } set { __title = value; __title_set = true;  } }
		private string __textblob = null;
		private bool __textblob_set = false;
		public virtual string TextBlob { get { if (!__textblob_set) __textblob = GetFieldValue<string>("TextBlob"); __textblob_set = true; return __textblob; } set { __textblob = value; __textblob_set = true;  } }
		private string __referencename = null;
		private bool __referencename_set = false;
		public virtual string ReferenceName { get { if (!__referencename_set) __referencename = GetFieldValue<string>("ReferenceName"); __referencename_set = true; return __referencename; } set { __referencename = value; __referencename_set = true;  } }
		private bool __minify;
		private bool __minify_set = false;
		public virtual bool Minify { get { if (!__minify_set) __minify = GetFieldValue<bool>("Minify"); __minify_set = true; return __minify; } set { __minify = value; __minify_set = true;  } }

	}
	public partial class AgilityJavascript : Agility.Web.AgilityContentItem
	{
		private string __title = null;
		private bool __title_set = false;
		public virtual string Title { get { if (!__title_set) __title = GetFieldValue<string>("Title"); __title_set = true; return __title; } set { __title = value; __title_set = true;  } }
		private string __textblob = null;
		private bool __textblob_set = false;
		public virtual string TextBlob { get { if (!__textblob_set) __textblob = GetFieldValue<string>("TextBlob"); __textblob_set = true; return __textblob; } set { __textblob = value; __textblob_set = true;  } }
		private string __referencename = null;
		private bool __referencename_set = false;
		public virtual string ReferenceName { get { if (!__referencename_set) __referencename = GetFieldValue<string>("ReferenceName"); __referencename_set = true; return __referencename; } set { __referencename = value; __referencename_set = true;  } }
		private bool __minify;
		private bool __minify_set = false;
		public virtual bool Minify { get { if (!__minify_set) __minify = GetFieldValue<bool>("Minify"); __minify_set = true; return __minify; } set { __minify = value; __minify_set = true;  } }

	}
	public partial class ContentPanel : Agility.Web.AgilityContentItem
	{
		private string __title = null;
		private bool __title_set = false;
		public virtual string Title { get { if (!__title_set) __title = GetFieldValue<string>("Title"); __title_set = true; return __title; } set { __title = value; __title_set = true;  } }
		private string __textarea = null;
		private bool __textarea_set = false;
		public virtual string Textarea { get { if (!__textarea_set) __textarea = GetFieldValue<string>("Textarea"); __textarea_set = true; return __textarea; } set { __textarea = value; __textarea_set = true;  } }
		private string __primarybutton = null;
		private bool __primarybutton_set = false;
		public virtual string PrimaryButton { get { if (!__primarybutton_set) __primarybutton = GetFieldValue<string>("PrimaryButton"); __primarybutton_set = true; return __primarybutton; } set { __primarybutton = value; __primarybutton_set = true;  } }
		private string __secondarybutton = null;
		private bool __secondarybutton_set = false;
		public virtual string SecondaryButton { get { if (!__secondarybutton_set) __secondarybutton = GetFieldValue<string>("SecondaryButton"); __secondarybutton_set = true; return __secondarybutton; } set { __secondarybutton = value; __secondarybutton_set = true;  } }
		private Attachment __image = null;
		public virtual Attachment Image { get {  if (__image == null) __image = GetAttachment("Image"); return __image; } set { __image = value; } }
		private string __imageposition = null;
		private bool __imageposition_set = false;
		public virtual string ImagePosition { get { if (!__imageposition_set) __imageposition = GetFieldValue<string>("ImagePosition"); __imageposition_set = true; return __imageposition; } set { __imageposition = value; __imageposition_set = true;  } }

	}
	public partial class Module_FormBuilder : Agility.Web.AgilityContentItem
	{
		private string __recordtypename = null;
		private bool __recordtypename_set = false;
		public virtual string RecordTypeName { get { if (!__recordtypename_set) __recordtypename = GetFieldValue<string>("RecordTypeName"); __recordtypename_set = true; return __recordtypename; } set { __recordtypename = value; __recordtypename_set = true;  } }
		private string __responsetype = null;
		private bool __responsetype_set = false;
		public virtual string ResponseType { get { if (!__responsetype_set) __responsetype = GetFieldValue<string>("ResponseType"); __responsetype_set = true; return __responsetype; } set { __responsetype = value; __responsetype_set = true;  } }
		private string __thankyoutemplate = null;
		private bool __thankyoutemplate_set = false;
		public virtual string ThankYouTemplate { get { if (!__thankyoutemplate_set) __thankyoutemplate = GetFieldValue<string>("ThankYouTemplate"); __thankyoutemplate_set = true; return __thankyoutemplate; } set { __thankyoutemplate = value; __thankyoutemplate_set = true;  } }
		private string __redirecturl = null;
		private bool __redirecturl_set = false;
		public virtual string RedirectURL { get { if (!__redirecturl_set) __redirecturl = GetFieldValue<string>("RedirectURL"); __redirecturl_set = true; return __redirecturl; } set { __redirecturl = value; __redirecturl_set = true;  } }
		private bool __includecaptcha;
		private bool __includecaptcha_set = false;
		public virtual bool IncludeCaptcha { get { if (!__includecaptcha_set) __includecaptcha = GetFieldValue<bool>("IncludeCaptcha"); __includecaptcha_set = true; return __includecaptcha; } set { __includecaptcha = value; __includecaptcha_set = true;  } }
		private string __errortemplate = null;
		private bool __errortemplate_set = false;
		public virtual string ErrorTemplate { get { if (!__errortemplate_set) __errortemplate = GetFieldValue<string>("ErrorTemplate"); __errortemplate_set = true; return __errortemplate; } set { __errortemplate = value; __errortemplate_set = true;  } }
		private bool __submitasemail;
		private bool __submitasemail_set = false;
		public virtual bool SubmitasEmail { get { if (!__submitasemail_set) __submitasemail = GetFieldValue<bool>("SubmitasEmail"); __submitasemail_set = true; return __submitasemail; } set { __submitasemail = value; __submitasemail_set = true;  } }
		private string __emailsendto = null;
		private bool __emailsendto_set = false;
		public virtual string EmailSendTo { get { if (!__emailsendto_set) __emailsendto = GetFieldValue<string>("EmailSendTo"); __emailsendto_set = true; return __emailsendto; } set { __emailsendto = value; __emailsendto_set = true;  } }
		private string __emailfrom = null;
		private bool __emailfrom_set = false;
		public virtual string EmailFrom { get { if (!__emailfrom_set) __emailfrom = GetFieldValue<string>("EmailFrom"); __emailfrom_set = true; return __emailfrom; } set { __emailfrom = value; __emailfrom_set = true;  } }
		private string __emailsubjecttemplate = null;
		private bool __emailsubjecttemplate_set = false;
		public virtual string EmailSubjectTemplate { get { if (!__emailsubjecttemplate_set) __emailsubjecttemplate = GetFieldValue<string>("EmailSubjectTemplate"); __emailsubjecttemplate_set = true; return __emailsubjecttemplate; } set { __emailsubjecttemplate = value; __emailsubjecttemplate_set = true;  } }
		private string __emailbodytemplate = null;
		private bool __emailbodytemplate_set = false;
		public virtual string EmailBodyTemplate { get { if (!__emailbodytemplate_set) __emailbodytemplate = GetFieldValue<string>("EmailBodyTemplate"); __emailbodytemplate_set = true; return __emailbodytemplate; } set { __emailbodytemplate = value; __emailbodytemplate_set = true;  } }
		private bool __customizeform;
		private bool __customizeform_set = false;
		public virtual bool CustomizeForm { get { if (!__customizeform_set) __customizeform = GetFieldValue<bool>("CustomizeForm"); __customizeform_set = true; return __customizeform; } set { __customizeform = value; __customizeform_set = true;  } }
		private string __submissionform = null;
		private bool __submissionform_set = false;
		public virtual string SubmissionForm { get { if (!__submissionform_set) __submissionform = GetFieldValue<string>("SubmissionForm"); __submissionform_set = true; return __submissionform; } set { __submissionform = value; __submissionform_set = true;  } }
		private bool __submitintougc;
		private bool __submitintougc_set = false;
		public virtual bool SubmitIntoUGC { get { if (!__submitintougc_set) __submitintougc = GetFieldValue<bool>("SubmitIntoUGC"); __submitintougc_set = true; return __submitintougc; } set { __submitintougc = value; __submitintougc_set = true;  } }

	}
	public partial class Module_PanelSlider : Agility.Web.AgilityContentItem
	{
		private string __panelsids = null;
		private bool __panelsids_set = false;
		public virtual string PanelsIDs { get { if (!__panelsids_set) __panelsids = GetFieldValue<string>("PanelsIDs"); __panelsids_set = true; return __panelsids; } set { __panelsids = value; __panelsids_set = true;  } }
		private IAgilityContentRepository<ContentPanel> __panels = null;
		public virtual IAgilityContentRepository<ContentPanel> Panels { get { if (__panels == null) __panels = GetLinkedContent<ContentPanel>("Panels"); return __panels; } set { __panels = value; }}

	}
	public partial class Module_RichTextArea : Agility.Web.AgilityContentItem
	{
		private string __textblob = null;
		private bool __textblob_set = false;
		public virtual string TextBlob { get { if (!__textblob_set) __textblob = GetFieldValue<string>("TextBlob"); __textblob_set = true; return __textblob; } set { __textblob = value; __textblob_set = true;  } }

	}

}
