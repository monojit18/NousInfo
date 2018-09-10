# Avanade Workshop

## Included projects (used in workshop):

1. SampleNuget - a Sample Nuget package creation project
2. TestFormsApp - A Sample Xamarin.Forms App
3. TestNativeApp - A Sample Xamarin.Native App
4. TestNuget - A Test project for testing SampleNuget package integration (1)
5. TestVSAppCenter - A Sample project for testing various things on VS App Center
6. TestAppCenter - Similar to (5) but also having functional UnitTest projects included

**Please note that some of the projects we are referencing Azure secured key information and hence those references have been
removed. So, to run those, you need to use Azure Free (30 day) subscription and create a correspionding key**

### Excercise 1:
1. Follow what has been done for *ISpeechService* in the **TestNativeApp** project. try to implement the same for Fingerprint
   and Contacts
2. Create interface named as *IFingerprintService* and *IContactsService*
3. Create a Shared Project and PCL Project
4. Implement platform specific implementations for Fingerprint and Contacts
5. Access Fingerprint service from Shared Project and Contacts Service from PCL project. Note the differences
6. Write Async service calls through fake API link: **https://jsonplaceholder.typicode.com/**
7. Download bulk images from **https://placeholder.com/** using Treadpool - decide how you want to implementy this.
   Refer deck for help

### Excercise 2:
1. Follow what has been done for **TestFormsApp** project
2. Create an additional page as *TabbedPage* - with one tab containing variosu controls but based on *RelativeLayout* and
   other tab is based on *AbsoluteLayout*. Notice the differences in approach and final implementation.
3. Add one Mater Detail page - with ListView, Boxview and Buttons - any kind of layout of your choice.
4. Try to add All button handlers through ICommand interface and access from corresponding ViewModel(s)
5. Try ot display dome popup on Button click. Since your Button handlers are implemented thru ICommand interface in ViewModel,
   so Decide - if you want to show it from ViewModel OR should message back to UI and show popup from there?
6. Select any one Button or ImageView (if used) and customize its appearences through Custom Renderers
7. Implememnt a threadpool operation (downloading of a large nuumber of images, say 1000) using a thread pool and Semaphore. Remeber we do not want 1000 threads to spin off!
8. Follow the attached deck to learn how Parallel should be used for CPU bound work. Implement something similar.
9. Look at the use of Attached Property and Bindable property. Extend this with more complex verison of those.

### Excercise 3:
1. Follow what has been done for **TestVSAppCenter** and **TestAppCenter**
2. Implement AppCenter Analytics for all the above pages (both forms app and Native App)
3. Create Xamarin.UITests for any one of the projects above and upload uinit tests to Test Cloud
4. Create a CI/CD pipeline through AppCenter - *Build*, *Test* (free 30 days), *Distribute* (amongst your team members)
5. Make sure to implement Functional Unit Tests as well for all the above projects
6. Look at the Push Notification integration with VS AppCenter. Try to enhance it with sending custom data from your AppCenter account. Create an appcenter account, configure it for PNS and then check in the code if notification is received.

Try to use some Azure account and configure Notification hub and then make necessary changes in iOS and Android codebase to recieve notification; please note that it will be different than the way it is done now!

