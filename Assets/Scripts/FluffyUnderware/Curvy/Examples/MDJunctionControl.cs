namespace FluffyUnderware.Curvy.Examples
{
	public class MDJunctionControl : CurvyMetadataBase, ICurvyMetadata
	{
		public bool UseJunction;

		public void Toggle()
		{
			UseJunction = !UseJunction;
		}
	}
}
