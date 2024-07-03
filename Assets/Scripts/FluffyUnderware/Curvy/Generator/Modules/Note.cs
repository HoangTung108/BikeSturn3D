using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("http://www.fluffyunderware.com/curvy/doclink/200/cgnote")]
	[ModuleInfo("Note", ModuleName = "Note", Description = "Creates a note")]
	public class Note : CGModule, INoProcessing
	{
		[SerializeField]
		[TextArea(3, 10)]
		private string m_Note;

		public string NoteText
		{
			get
			{
				return m_Note;
			}
			set
			{
				if (m_Note != value)
				{
					m_Note = value;
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Properties.MinWidth = 200f;
			Properties.LabelWidth = 50f;
		}
	}
}
