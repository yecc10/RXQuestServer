using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecnomatix;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.Utilities;
using Tecnomatix.Engineering.Ui;
using Tecnomatix.Engineering.ModelObjects;
using Tecnomatix.Engineering.DataTypes;
using Tecnomatix.Engineering.ViewModelObjects;
using System.Diagnostics;

namespace Tecnomatix
{
    public partial class PSimulateQuickServer : Form
    {
        public PSimulateQuickServer()
        {
            InitializeComponent();
        }

        private void cUiContinuousButton1_Click(object sender, EventArgs e)
        {
            //Snapshots can be retrieved from under the physical root using a type filter that will filter out only snapshots. 
            TxTypeFilter filter = new TxTypeFilter(typeof(TxSnapshot));
            TxObjectList snapshots = TxApplication.ActiveDocument.PhysicalRoot.GetDirectDescendants(filter);
            foreach (TxSnapshot s in snapshots)
            {
                string st = s.Name;
            }
            //Retrieve a selected snapshot (existing functionality) 
            TxSnapshot snapshot = null;
            TxObjectList selList = TxApplication.ActiveSelection.GetItems();
            if (selList.Count == 1)
            {
                snapshot = selList[0] as TxSnapshot;
            }
            //The snapshots creation data class should be created with the new snapshot name, and then sent to the CreateSnapshot function that will create it under the root.
            //The current state of the Graphic Viewer will be captured in the snapshot.
            TxSnapshotCreationData creationData = new TxSnapshotCreationData("snapshotName");
            TxApplication.ActiveDocument.PhysicalRoot.CreateSnapshot(creationData);

            //The Update() function of the TxSnapshot class should be used.
            //The current state of the Graphic Viewer will be captured in the snapshot. 

            snapshot = null;
            selList = TxApplication.ActiveSelection.GetItems();
            if (selList.Count == 1)
            {
                snapshot = selList[0] as TxSnapshot;
            }
            if (snapshot != null)
            {
                snapshot.Update();
            }

            //Apply an existing snapshot(new functionality) 
            //The Apply() function of the TxSnapshot class should be used, with a parameters class that describes what aspect of the snapshot to apply.
            //The TxApplySnapshotParams class is a new data class to hold the apply preferences.
            //The user should configure the following parameters (the default for all parameters is false): 
            //DevicePoses - Specifies whether applying the snapshot should affect the poses of the devices(should it jump the devices to the poses that they are in, in the snapshot). 
            //ObjectsAttachments - Specifies whether applying the snapshot should affect the attachments of the objects(should it attach the attachments to the objects that they are attached to in the snapshot). 
            //ObjectsColor - Specifies whether applying the snapshot should affect the color of the objects(should it change objects' colors that they are in, in the snapshot). 
            //ObjectsLocation - Specifies whether applying the snapshot should affect the location of the objects (should it move the objects to the locations that they are in, in the snapshot). 
            //ObjectsViewingMode - Specifies whether applying the snapshot should affect the viewing mode of the objects(should it change the viewing mode of the objects, according to the state that they are in, in the snapshot). 
            //ObjectsVisibility - Specifies whether applying the snapshot should affect the visibility of the objects(should it blank/display the objects, according to the state that they are in, in the snapshot). 
            //PMIsScale - Specifies whether applying the snapshot should affect the scaling of PMIs(should it change the scaling of PMIs, according to the state that they are in, in the snapshot). 
            //PointOfView - Specifies whether applying the snapshot should affect the point of view.
            //Following is code for configuring the parameters and applying the snapshot: 
            TxApplySnapshotParams parameters = new TxApplySnapshotParams();
            parameters.DevicePoses = true;
            parameters.ObjectsAttachments = true;
            parameters.ObjectsColor = true;
            parameters.ObjectsLocation = true;
            parameters.ObjectsViewingMode = true;
            parameters.ObjectsVisibility = true;
            parameters.PMIsScale = true;
            parameters.PointOfView = true;
            snapshot.Apply(parameters);

            TxObjectList objects;
            // the user fills the objectList
            objects = null;
            TxClipboardData clipboardData = new TxClipboardData();
            clipboardData.Objects = objects;
            // convert the data to IDataObject that will be set in the DoDragDrop:
            TxDragAndDropClipboardServices services = new TxDragAndDropClipboardServices();
            IDataObject dataObject;
            services.CopyToDataObject(clipboardData, out dataObject);
            // start a drag and drop operation:
            DoDragDrop(dataObject, DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move);


            // Prepare the cylinder creation data
            TxCylinderCreationData cd = new TxCylinderCreationData();
            cd.Name = "myCylinder";
            cd.Base = new TxVector(0, 0, 0);
            cd.Top = new TxVector(0, 0, 300);
            cd.Radius = 100;
            // Get the first item from the selection
            TxObjectList selectedItems = TxApplication.ActiveSelection.GetItems();
            ITxGeometryCreation geoParent = selectedItems[0] as ITxGeometryCreation;

            // If the selected item is of a type under which a geometry can be created
            // (that is, if it implements ITxGeometryCreation), create the cylinder
            // under it.
            if (geoParent != null)
                geoParent.CreateSolidCylinder(cd);

            // Get the first item from the selection.

            TxObjectList selectedList = TxApplication.ActiveSelection.GetItems();
            ITxLocatableObject obj = selectedList[0] as ITxLocatableObject;
            // If the item is locatable, write its location to the output window.
            //if (loc != null)
            //{
            //    TxTransformation loc = obj.AbsoluteLocation;

            //    Debug.Write("\n\nThe location of " + ((ITxObject)obj).Name + " as a matrix:");
            //    Debug.Write("\n" + loc.ToString());
            //    Debug.Write("\n\nThe translation of " + ((ITxObject)obj).Name + ":");
            //    Debug.Write("\n" + loc.Translation.ToString());
            //    Debug.Write("\n\nThe RPY rotation of " + ((ITxObject)obj).Name + ":");
            //    Debug.Write("\n" + loc.RotationRPY_XYZ.ToString());
            //}

        }

        //Getting Objects from the clipboard 
        private void DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TxDragAndDropClipboardServices clipboardServices = new TxDragAndDropClipboardServices();

            // verify that the data has the right format:
            if (e.Data.GetDataPresent(clipboardServices.Format))
            {
                // get the ClipboardData:
                ITxClipboardData clipboardData;
                clipboardServices.CopyFromDataObject(e.Data, out clipboardData);
                TxClipboardData cData = clipboardData as TxClipboardData;
                // the objects list is inside the clipboard data
            }
        }

    }
}
