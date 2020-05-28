# MIPCDVIZ: 
3D Medical Image Processing for Surgical Planning and Vizualization

Our tool provides the following functionalities for 2D->3D vizualization:
- View a set of 2D images as a composited 3D volume in Virtual Reality
    - our custom engines provides an exceptionally high framerate to level of detail ratio
    - using the most cutting edge high definition rendering backed by current research. 
        
- Automatically segment organs for immediate vizual clarity 
    - machine learning; neural networks and other custom artificial intelligence techniques color segment the internal landscape
- Fully customize and highlight your own areas of interest 
    - easy to use section/tissue density based color mapping 
        - Acutely adjustable automatic contrast for your preferred vizual isolation level
    - cut into or omit areas of the volume to isolate areas of interest
    - adjust contrast, transparency, and brightness preferentially
    <br>
         <img src="https://cdn.discordapp.com/attachments/687762053058003003/710052270074494976/unknown.png" width="400">
    <br>
    
    

How To Get Started:
1. Install our VR application and importer tool on your destop!
2. Add the Dicoms you'd like to view
3. We do our medical image processing magic to automatically segment organs within your stacks of 2D images
4. Open our VR application 
5. Dissect, Discuss, Explore, and Plan around this novel Medical Data Viewing experience!


Using the VR Application:
Basic VR controls:  

Adding your DICOMS to our MVP Application:
- First you'll need to add any dicoms you'd like to view in our application using our handy importer tool!
- Go ahead and double click the importer shortcut <icon image> and select the files you'd like to add from your file browser.
- After finding the stack you'd like to import, hit import on the folder containing all the images.
      - newly imported data will be the easiest to find in our file browser in the VR app!
- You can then explore in detail your newly AI segmented 3D medical data
    
Choosing Your Dicom Stack In VR:
- On the left side of the room when you enter the VR world, you'll see all the Dicom files that you have loaded in with our importer
- You can choose to select from only those with auto segmented masks, or by most recently added with the arrow at the top
- Stacks are sorted by patient name, then date and scan paramters/name
- after you have selected your patient and data set, you will be asked to confirm your selection with more detailed information. Hit confirm to view and interact with the 3D model

Interacting With the 3D Volume:
- After you have selected a data stack, the volume will load in in front of you. 
