Babylon Editor Toolkit 2024 - Version: 7.50.1
==============================================
Author: Mackey Kinard
Email:  MackeyK24@gmail.com
Web:    https://www.babylontoolkit.com
==============================================

Built With Unity Editor Version
* Unity Editor 2022.3.33f1 Binaries
* Xcode 12.4 (Catalina 10.15.7) Binaries
* Omnisharp: Use Global Mono" to "always"


CanvasTools Metafile Guid
* aed35ab8415a4438d98ea4d52ed10a6e


Babylon Game Framework Version
* Build With 7.50.1 - R1


Cubemap Filter Tools Version
* Updated: 02 May 2015


Default Babylon Color Schemes
* Primary Color: #2A2342
* Secondary Color: #E0684B
* Highlight Color: #00FF00


Project Config Folder Files
* Project Settings File (settings.json)
* Custom Index Export Page (index.html)
* Custom Engine Export Page (engine.html)


Shaders Store Packaging
* Fragment Shader Files - shader.fragment.fx
* Vertex Shader Files - shader.vertex.fx
* Particle Shader Files - shader.particle.fx
* Include Shader Files - shader.include.fx


Hammer Touch - https://hammerjs.github.io/


UNI Collider - https://github.com/sanukin39/UniColliderInterpolator


LOD Generator - https://github.com/Whinarn/UnityMeshSimplifier


Animation Combiner - https://nilooy.github.io/character-animation-combiner/


Profanity Cleaner - https://www.jsdelivr.com/package/npm/profanity-cleaner


GLTF Model Import Tools - Ready Player Me Edition (https://github.com/Siccity/GLTFUtility)
  - To ensure that Unity includes the GLTFUtility shaders in builds, you must add these shaders to the 'Always Included Shaders' list.
  - Open Edit -> Project Settings
  - Open Graphics
  - Scroll to Always Included Shaders
  - Under Size, increase the value by 4 and hit Enter.
  - In the Project panel, navigate to BabylonToolkit/Importer/Materials/Built-in.
  - In this directory are 4 .shader files.
  - Drag and drop each of the 4 files into one of the 4 newly created rows in Always Included Shaders.


Multiplayer Engine Support
* Colyseus (Version 0.14.13)
* https://www.colyseus.io/
* https://docs.colyseus.io/colyseus/


Recast Navigation System
* Manually Placed Native Off Mesh Link Components Only


TODO Babylon Toolkit Editor Items
* Support Multi Level Detail Renderers (LOD)
* Better Unity WebView Browser With Request Headers


Unity Editor Platform Notes
* Khronos Texture Tools - 4.0.0
  https://github.com/KhronosGroup/KTX-Software/releases
  https://github.khronos.org/KTX-Software/ktxtools/toktx.html


* Unity Cascaded Shadow Map Genertors
  https://doc.babylonjs.com/babylon101/shadows_csm
  Note: Realtime shadows in second viewport has issues


* Unity Vertex Snapping
- Use vertex snapping to quickly assemble your Scenes: take any vertex from a given Mesh and place that vertex in the same position as any vertex from any other Mesh you choose.
- For example, use vertex snapping to align road sections precisely in a racing game, or to position power-up items at the vertices of a Mesh.
- Follow the steps below to use vertex snapping:
1. Select the Mesh you want to manipulate and make sure the Move tool is active.
2. Press and hold the V key to activate the vertex snapping mode.
3. Move your cursor over the vertex on your Mesh that you want to use as the pivot point.
4. Hold down the left mouse button once your cursor is over the vertex you want and drag your Mesh next to any other vertex on another Mesh.
To snap a vertex to a surface on another Mesh, add and hold down the Shift+Ctrl (Windows) or Shift+Command (macOS) key while you move over the surface you want to snap to.
To snap the pivot to a vertex on another Mesh, add and hold the Ctrl (Windows) or Command (macOS) key while you move the cursor to the vertex you want to snap to.
Release the mouse button and the V key when you are happy with the results (Shift+V acts as a toggle of this functionality).


* Compiler Symlinks (Node Version Manager)
===========================================
- Node: ln -s -f /Users/name/.nvm/versions/node/v14.11.0/bin/node /usr/local/bin/node
- Tsc:  ln -s -f /Users/name/.nvm/versions/node/v14.11.0/bin/tsc /usr/local/bin/tsc


* Github Ignore Settings
=========================
# Babylon Toolkit #
Export/
Debug/
Logs/
debug.log
tsexport.txt
.DS_Store

# Node Related # 
node_modules/
package-lock.json

# Unity User Settings #
UserSettings/

# Ignore Root Config Only #
/tsconfig.json

# Ignore Playground Scripts #
/playground.sh
/playground.bat


* Github FLS Attributes
========================
*.mp4 filter=lfs diff=lfs merge=lfs -text
*.psd filter=lfs diff=lfs merge=lfs -text
*.dds filter=lfs diff=lfs merge=lfs -text


* Github Hard Reset Commands
=============================
- git reset --hard <commit_id>
- git push --force


* Github Submodule Pull Commands
=================================
  - git pull --recurse-submodules
  - git submodule update --remote


* Using Github Assets (raw.githubusercontent.com)
==================================================
  - Ensure that your git repo is set to public
  - Navigate to your file. We'll take as example https://github.com/BabylonJS/MeshesLibrary/blob/master/PBR_Spheres.glb
  - Remove /blob/ part
  - Replace https://github.com by https://raw.githubusercontent.com
  - You now have raw access to your file https://raw.githubusercontent.com/BabylonJS/MeshesLibrary/master/PBR_Spheres.glb
  - Example: var mx = await BABYLON.SceneLoader.ImportMeshAsync("", "https://raw.githubusercontent.com/MackeyK24/MackeyK24.github.io/master/temp/", "RightHandBot.glb", scene);


* Disable SRGB Buffer Support
============================
- engine.getCaps().supportSRGBBuffers = false;


* AWS Elastic Beanstalk Virtual Private Server
===============================================
  - udp ports 0 to 65535
  - tcp ports 80, 443, 2567
  - sudo su; sudo chmod -R 777 /root; sudo mkdir -p /root/.npm; sudo chown -R webapp:webapp /root/.npm


* External Tools Access Denied (Mac)
====================================================
  - chmod +x Packages/com.babylontoolkit.editor/Libraries/Filter/cmft_osx64/cmft
  - chmod +x Packages/com.babylontoolkit.editor/Libraries/Texture/osx64/toktx


* Self Signed Certificates
====================================================
# Clear Local Host Cache (Optional)
- sudo killall -HUP mDNSResponder;sudo killall mDNSResponderHelper;sudo dscacheutil -flushcache

# Update Local Host File (Optional)
- edit /etc/hosts file
- 127.0.0.1 or x.x.x.x express.local
- sudo dscacheutil -flushcache

# Trust Self Signed Certificate (Optional)
- trust your self signed express dev certificate (express.cert.p12) with keychain access or mmc

# Update Self Signed Certificates (Optional)
- from include/certificates folder
- touch express.san.ext (add text below)
```
subjectKeyIdentifier   = hash
authorityKeyIdentifier = keyid:always,issuer:always
basicConstraints       = CA:TRUE
keyUsage               = digitalSignature, nonRepudiation, keyEncipherment, dataEncipherment, keyAgreement, keyCertSign
subjectAltName         = DNS:*.express.local, DNS:express.local, DNS:localhost
issuerAltName          = issuer:copy
```
- openssl req -newkey rsa:2048 -nodes -days 365000 -keyout express.key.pem -out express.csr.pem -subj '/CN=*.express.local'
- openssl x509 -req -in express.csr.pem -signkey express.key.pem -out express.cert.pem -days 365000 -sha256 -extfile express.san.ext

# Assign Self Signed Certificate To Port (MacOS)
- openssl pkcs12 -export -out express.cert.p12 -inkey express.key.pem -in express.cert.pem
- httpcfg -add -port 4444 -p12 express.cert.p12 -pwd password

# Assign Self Signed Certificate To Port (Windows)
- openssl pkcs12 -export -out express.cert.p12 -inkey express.key.pem -in express.cert.pem
- netsh http add sslcert ipport=0.0.0.0:4444 certhash=bb14d78228ff2c8965de040c2cc1a1fff3132d76 appid={B8CA0613-6250-4DDB-A693-74B8678C2DF6}


* Yield Wait For Seconds
=========================
let testAsync = async () => { // From an async function you can Yield and wair for seconds
    for (var i = 0; i < 30; i++) {
      console.log(i);
      await TOOLKIT.SceneManager.WaitForSeconds(75);
    }
}
testAsync();


* Experimental Decarators
==========================
module Backing {
    export function Class(klass: string) {
        return function (constructor: Function) {
            constructor.prototype.__classname = klass;
        }        
    }
}

namespace PROJECT {
  @Backing.Class("PROJECT.TestClass");
  export class TestClass extends TOOLKIT.ScriptComponent {
    ...
  }
}


* Deltakosh Test Playgrounds
================================
- Cameras:  https://playground.babylonjs.com/#L92PHY#36
- Lights:   https://playground.babylonjs.com/#CQNGRK#490


* Tester Playground
=========================
- https://playground.babylonjs.com/#KXLBRQ?UnityToolkit


* Bone IK Controller
=========================
- https://playground.babylonjs.com/#1EVNNB#230
- https://www.babylonjs-playground.com/#4HTBYP#12
- https://playground.babylonjs.com/#D0T14K#4?UnityToolkit (GLTF)
- https://playground.babylonjs.com/#D0T14K#3?UnityToolkit (BABYLON)


* Demo Grass Shaders
=====================
- https://playground.babylonjs.com/#KBXIPD#22
- https://playground.babylonjs.com/#NZDFUB#3
- https://playground.babylonjs.com/#A0YCX2#8
- https://nme.babylonjs.com/#8WH2KS#22


* VR Physics Playgrounds
============================
- https://playground.babylonjs.com/#B922X8#19


* VR Simple Grab Playgrounds
=============================
- https://playground.babylonjs.com/#9M1I08#5


* VR Hand Tracking Playgrounds
===============================
- https://playground.babylonjs.com/#X7Y4H8#16


* VR Throwing Lab Playgrounds
===============================
- https://playground.babylonjs.com/#K1WGX0#36


* Network Player Name Labels
==============================
- https://playground.babylonjs.com/#PCXU1B#9


============================================
All rights reserved (c) 2020 Mackey Kinard