#if UNITY_IOS
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode.Extensions;

namespace Tabtale.TTPlugins
{
    public class TTPPostProcessSettings
    {
        private static PlistElementDict rootDict;

        [PostProcessBuild(40005)]
        public static void OnPostProcessBuild(BuildTarget target, string path)
        {
            var pbxProjectPath = UnityEditor.iOS.Xcode.PBXProject.GetPBXProjectPath(path);
            var pbxProject = new UnityEditor.iOS.Xcode.PBXProject();
            pbxProject.ReadFromString(System.IO.File.ReadAllText(pbxProjectPath));

            Debug.Log("TTPPostProcessSettings::Add swift support for mopub and ecpm");
            pbxProject.AddBuildProperty(GetTargetGUID(pbxProject), "LIBRARY_SEARCH_PATHS", "$(TOOLCHAIN_DIR)/usr/lib/swift/$(PLATFORM_NAME)");
            pbxProject.AddBuildProperty(GetTargetGUID(pbxProject), "LIBRARY_SEARCH_PATHS", "$(SDKROOT)/usr/lib/swift");
            pbxProject.SetBuildProperty(GetTargetGUID(pbxProject), "LD_RUNPATH_SEARCH_PATHS", "/usr/lib/swift $(inherited) @executable_path/Frameworks");
            pbxProject.SetBuildProperty(GetTargetGUID(pbxProject), "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
            pbxProject.SetBuildProperty(GetTargetGUID(pbxProject), "SWIFT_VERSION", "5");
#if UNITY_2019_3_OR_NEWER
            var unityFrameworkTarget = pbxProject.GetUnityFrameworkTargetGuid();
            pbxProject.AddBuildProperty(unityFrameworkTarget, "LIBRARY_SEARCH_PATHS", "$(TOOLCHAIN_DIR)/usr/lib/swift/$(PLATFORM_NAME)");
            pbxProject.AddBuildProperty(unityFrameworkTarget, "LIBRARY_SEARCH_PATHS", "$(SDKROOT)/usr/lib/swift");
            pbxProject.SetBuildProperty(unityFrameworkTarget, "LD_RUNPATH_SEARCH_PATHS", "/usr/lib/swift $(inherited) @executable_path/Frameworks");
            pbxProject.SetBuildProperty(unityFrameworkTarget, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "NO");
            pbxProject.SetBuildProperty(unityFrameworkTarget, "SWIFT_VERSION", "5");

            var mainTargetLinkFrameworksId = pbxProject.GetFrameworksBuildPhaseByTarget(pbxProject.GetUnityMainTargetGuid());
            var unityFrameworkBuildProductId = pbxProject.GetTargetProductFileRef(pbxProject.GetUnityFrameworkTargetGuid());
            Debug.Log("Linking unity framework to main target to support unity 2020 - " + mainTargetLinkFrameworksId + ", " + unityFrameworkBuildProductId);
            pbxProject.AddFileToBuildSection(pbxProject.GetUnityMainTargetGuid(), mainTargetLinkFrameworksId, unityFrameworkBuildProductId);
            
            
#endif

#if UNITY_2019_3_OR_NEWER

            //Add BUAdASDK.bundle
            string pathToBUAdSDK = "Data/Raw/Bundle/BUAdSDK.bundle";
            string absPathToBUADSDK = Path.Combine(path, pathToBUAdSDK);

            if (Directory.Exists(absPathToBUADSDK))
            {
                Debug.Log("TTPPostProcessSettings :: Adding BUAdSDK.bundle");
                pbxProject.AddFileToBuild(GetTargetGUID(pbxProject), pbxProject.AddFile(pathToBUAdSDK, "BUAdSDK.bundle"));
            }
            else
            {
                Debug.Log("TTPPostProcessSettings :: BUAdSDK.bundle not exists");
            }
            //END BUAdSDK
            
            string pathToTapJoyBundle = "Data/Raw/Bundle/TapjoyResources.bundle";
            string absPathTapJoyBundle = Path.Combine(path, pathToBUAdSDK);

            if (Directory.Exists(absPathTapJoyBundle))
            {
                Debug.Log("TTPPostProcessSettings :: Adding TapjoyResources.bundle");
                pbxProject.AddFileToBuild(GetTargetGUID(pbxProject), pbxProject.AddFile(pathToTapJoyBundle, "TapjoyResources.bundle"));
            }
            else
            {
                Debug.Log("TTPAddTiktokBundle.cs :: TapjoyResources.bundle not exists");
            }
#endif

            File.WriteAllText(pbxProjectPath, pbxProject.WriteToString());

            var plistPath = Path.Combine(path, "Info.plist");
            var plist = new PlistDocument();
            plist.ReadFromFile(plistPath);
            rootDict = plist.root;

            rootDict.SetBoolean("GOOGLE_ANALYTICS_DEFAULT_ALLOW_AD_PERSONALIZATION_SIGNALS", false);
            rootDict.SetBoolean("FIREBASE_ANALYTICS_COLLECTION_ENABLED", false);
            
            
            // Add AppLovinSdkKey
            if (Application.identifier == "com.tabtaleint.ttplugins" ||
                Application.identifier == "com.tabtaleint.ttplugins" ||
                Application.identifier == "com.tabtaleint.ttplugins")
            {
                rootDict.SetString("AppLovinSdkKey", "yRHC8kgWwG5S4lOh7Dx_pZB2iEBLVWMSzde5MKbGahifQ6MTKIT7tk9ZzLvTsFwptZvDuVTTBB8cHU9bohkeQu");
            }
            else
            {
                rootDict.SetString("AppLovinSdkKey", "TREvWeSbneklepMTdxWL5KCqUD57xezP4CIarlBcOwM1kiVMe0hkLvTq7dy3HwSL6mxyV7Tu1wwlcP5FQo-nhW");
            }


            var array = rootDict.CreateArray("SKAdNetworkItems");
            //admob
            array.AddDict().SetString("SKAdNetworkIdentifier","cstr6suwn9.skadnetwork");
            //applovin
            array.AddDict().SetString("SKAdNetworkIdentifier","ludvb6z3bs.skadnetwork");
            //ironsource
            array.AddDict().SetString("SKAdNetworkIdentifier","su67r6k2v3.skadnetwork");
            //adcolony
            array.AddDict().SetString("SKAdNetworkIdentifier","4pfyvq9l8r.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","4fzdc2evr5.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","4468km3ulz.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","3rd42ekr43.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","m8dbw4sv7c.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","ejvt5qm6ak.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","mtkv5xtk9e.skadnetwork");
            //chartboost
            array.AddDict().SetString("SKAdNetworkIdentifier","f38h382jlk.skadnetwork");
            //facebook
            array.AddDict().SetString("SKAdNetworkIdentifier","v9wttpbfk9.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","n38lu8286q.skadnetwork");
            //hypermx
            array.AddDict().SetString("SKAdNetworkIdentifier","nu4557a4je.skadnetwork");
            //inmobi
            array.AddDict().SetString("SKAdNetworkIdentifier","wzmmz9fp6w.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","uw77j35x4d.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","7ug5zh24hu.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","hs6bdukanm.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","ggvn48r87g.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","5lm9lj6jb7.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","9rd848q2bz.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","c6k4g5qg8m.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","3sh42y64q3.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","yclnxrl5pm.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","f73kdq92p3.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","ydx93a7ass.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","w9q455wk68.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","prcb7njmu6.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","wg4vff78zm.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","mlmmfzh3r3.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","tl55sbb4fm.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","t38b2kh725.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","5l3tpt7t6e.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","7rz58n8ntl.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","klf5c3l5u5.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","cg4yq2srnc.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","av6w8kgt66.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","9t245vhmpl.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","v72qych5uu.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","2u9pt9hc89.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","44jx6755aq.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","8s468mfl3y.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","p78axxw29g.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","ppxm28t8ap.skadnetwork");
            //mintegral
            array.AddDict().SetString("SKAdNetworkIdentifier","kbd757ywx3.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","glqzh8vgby.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","6xzpu9s2p8.skadnetwork");
            //pangle
            array.AddDict().SetString("SKAdNetworkIdentifier","22mmun2rn5.skadnetwork"); //non cn
            array.AddDict().SetString("SKAdNetworkIdentifier","238da6jt44.skadnetwork"); //cn
            //tapjoy
            array.AddDict().SetString("SKAdNetworkIdentifier","ecpz2srf59.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","578prtvx9j.skadnetwork");
            //unity ads
            array.AddDict().SetString("SKAdNetworkIdentifier","4dzt52r2t5.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","488r3q3dtq.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","zmvfpc5aq8.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","v79kvwwj4g.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","lr83yxwka7.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","44n7hlldy6.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","424m5254lk.skadnetwork");
            //vungle
            array.AddDict().SetString("SKAdNetworkIdentifier","gta9lk7p23.skadnetwork");
            //mopub
            array.AddDict().SetString("SKAdNetworkIdentifier","cdkw7geqsh.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","qyjfv329m4.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","3qy4746246.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","523jb4fst2.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","5a6flpkh64.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","737z793b9f.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","7953jerfzd.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","97r2b46745.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","9yg77x724h.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","bvpn9ufa9b.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","cj5566h2ga.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","gvmwg8q7h5.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","mls7yz5dvl.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","n66cz3y3bx.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","n9x2a789qt.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","nzq8sh4pbs.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","pu4na253f3.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","u679fj5vs4.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","xy9t38ct57.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","z4gj7hsk7h.skadnetwork");

            array.AddDict().SetString("SKAdNetworkIdentifier","s39g8k73mm.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","24t9a8vw3c.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","yrqqpx2mcb.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","52fl2v3hgk.skadnetwork");
            
            array.AddDict().SetString("SKAdNetworkIdentifier","424mk524lk.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","n6fk4nfna4.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","2fnua5tdw4.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","k674qkevps.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","y2ed4ez56y.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","6g9af3uyq4.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","rx5hdcabgc.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","g28c52eehv.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","9nlqeag3gk.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","275upjj5gd.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","e5fvkxwrpn.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","zq492l623r.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","hjevpa356n.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","3qcr597p9d.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","feyaarzu9v.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","4w7y6s5ca2.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","dzg6xy7pwj.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","y45688jllp.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","hdw39hrw9y.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","5tjdwbrq8w.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","x44k69ngh6.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","pwa73g5rt2.skadnetwork");

            array.AddDict().SetString("SKAdNetworkIdentifier","r26jy69rpl.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","f7s53z58qe.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","252b5q8x7y.skadnetwork");
            array.AddDict().SetString("SKAdNetworkIdentifier","32z4fx6l9h.skadnetwork");
            
            
            // fix problem with statusbar on iOS 14
            if (!rootDict.values.ContainsKey("UIViewControllerBasedStatusBarAppearance"))
            {
                rootDict.SetBoolean("UIViewControllerBasedStatusBarAppearance", false);
            }
            

            File.WriteAllText(plistPath, plist.WriteToString());
        }

        private static string GetTargetGUID(PBXProject proj)
        {
#if UNITY_2019_3_OR_NEWER
        return proj.GetUnityMainTargetGuid();
#else
            return proj.TargetGuidByName("Unity-iPhone");
#endif
        }


    }

}
#endif
