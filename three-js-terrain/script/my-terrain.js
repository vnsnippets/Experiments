console.log("MY TERRAIN")

import * as THREE from './three.module.js';

export const Render3D = () => {
   const sizes = {
      width: window.innerWidth - 25,
      height: window.innerHeight - 25
   }

   // Loaders
   const textureLoader = new THREE.TextureLoader();
   const texture = textureLoader.load('../assets/lava-ground-2.png');
   const displacement = textureLoader.load('../assets/cloud-map.jpg');
   const alpha = textureLoader.load('../assets/alpha-map-ppt.png');

   // Canvas
   const CANVAS = document.querySelector('#canvas');

   // Scene
   const SCENE = new THREE.Scene();

   const terrainGeometry = new THREE.PlaneBufferGeometry(3, 3, 64, 64);
   const terrainMaterial = new THREE.MeshStandardMaterial({
      color: 0xFFFFFF,
      map: texture,
      displacementMap: displacement,
      displacementScale: 0.5,
      alphaMap: alpha,
      transparent: true,
      depthTest: true
   })
   const terrain = new THREE.Mesh(terrainGeometry, terrainMaterial);
   SCENE.add(terrain);
   terrain.rotation.x = 181;

   // Lights
   const pointLight = new THREE.PointLight(0x964343, 3);
   pointLight.position.x = -3;
   pointLight.position.y = 3;
   pointLight.position.z = 4;

   SCENE.add(pointLight);

   // Renderer
   const RENDERER = new THREE.WebGLRenderer({
      canvas: CANVAS,
      alpha: true
   })
   RENDERER.setSize(sizes.width, sizes.height)
   RENDERER.setPixelRatio(Math.min(window.devicePixelRatio, 2))

   // Camera
   const CAMERA = new THREE.PerspectiveCamera(75, sizes.width / sizes.height, 0.1, 100)
   CAMERA.position.x = 0
   CAMERA.position.y = 0
   CAMERA.position.z = 3
   SCENE.add(CAMERA)

   window.addEventListener('resize', () => {
      // Update body sizes
      console.log(sizes);

      // Update camera
      CAMERA.aspect = sizes.width / sizes.height
      CAMERA.updateProjectionMatrix()

      // Update renderer
      RENDERER.setSize(sizes.width, sizes.height)
      RENDERER.setPixelRatio(Math.min(window.devicePixelRatio, 2))
   });

   // Animation
   const mouse = {
      x: 0,
      y: 0
   }
   document.addEventListener('mousemove', (event) => {
      mouse.x = event.clientX,
         mouse.y = event.clientY
   })

   const clock = new THREE.Clock()

   const tick = () => {
      const elapsedTime = clock.getElapsedTime()

      terrain.rotation.z = .5 * elapsedTime;

      terrain.material.displacementScale = 0.5 + mouse.y * .00025;

      // Render
      RENDERER.render(SCENE, CAMERA)

      // Call tick again on the next frame
      window.requestAnimationFrame(tick)
   }

   tick()

   // DAT GUI SETUP
   // const GUI = new DAT.GUI();
   // const lightStep = 0.01;
   // const lightFolder = GUI.addFolder('Light');
   // lightFolder.add(pointLight.position, 'x').min(-10).max(10).step(lightStep);
   // lightFolder.add(pointLight.position, 'y').min(-10).max(10).step(lightStep);
   // lightFolder.add(pointLight.position, 'z').min(-10).max(10).step(lightStep);

   // const light = {
   //    color: 0x000000
   // };
   // lightFolder.addColor(light, 'color').onChange(() => {
   //    pointLight.color.set(light.color);
   // })

   // const planeStep = 0.01;
   // const planeFolder = GUI.addFolder('Plane');
   // planeFolder.add(terrain.rotation, 'x').min(-10).max(10).step(planeStep);
   // planeFolder.add(terrain.rotation, 'y').min(-10).max(10).step(planeStep);
   // planeFolder.add(terrain.rotation, 'z').min(-10).max(10).step(planeStep);
}