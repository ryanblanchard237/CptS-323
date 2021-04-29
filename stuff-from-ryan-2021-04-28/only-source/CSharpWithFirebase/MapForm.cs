using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpWithFirebase
{
	public partial class MapForm : Form
	{
		public MapForm()
		{
			InitializeComponent();
		}

		// http://www.independent-software.com/gmap-net-beginners-tutorial-maps-markers-polygons-routes-updated-for-vs2015-and-gmap1-7.html

		private void buttonTalkToFirebaseForm(object sender, EventArgs e)
		{
			TalkToFirebaseForm f1 = new TalkToFirebaseForm();
			f1.Show();
		}

		private void gMapControl1_Load(object sender, EventArgs e)
		{
			this.gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			// Without doing further research the above line makes sense to me.

			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
			// Dont really know what this line does.

			gMapControl1.SetPositionByKeywords("Paris, France");
		}

		private void buttonProspectListForm_Click(object sender, EventArgs e)
		{
			Form plf = new ProspectListForm();
			plf.Show();
		}
	}
}
