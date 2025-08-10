# Procedural Mesh Generator (Unity3D)

A lightweight Unity3D tool for generating meshes (Cube, Plane, Sphere) **entirely from code** with real-time parameter control in the Inspector.  
Perfect for showcasing procedural geometry, mesh manipulation, and editor scripting skills.

---

## ✨ Features
- **Procedural Meshes**: Cube, Plane, Sphere — no pre-made assets.
- **Real-time Updates**: Change shape, size, and resolution in the Inspector.
- **Clean & Minimal**: Single script (`MeshGenerator.cs`) with no dependencies.
- **Fully Customizable**: Easy to extend for more shapes (cylinders, cones, etc.).

---

## 🎥 Demo
![Procedural Mesh Generator Demo](demo.gif)

---

## 🛠️ How to Use
1. Create a new **Unity 2021+** project.
2. Drag `MeshGenerator.cs` into your project (e.g., `Assets/Scripts/`).
3. Create an empty GameObject in the scene.
4. Attach the `MeshGenerator` script.
5. Assign any material to the MeshRenderer.
6. Adjust **Shape**, **Size**, and **Resolution** in the Inspector — mesh updates instantly.

---

## 📸 Example Settings
| Shape  | Size | Resolution |
|--------|------|------------|
| Cube   | 1    | N/A        |
| Plane  | 5    | 20         |
| Sphere | 1.5  | 24         |

---

## 💡 Extending the Tool
You can add new shapes by:
1. Adding a new option to the `ShapeType` enum.
2. Creating a new `GenerateYourShape()` method.
3. Calling it inside `GenerateMesh()`.

---

## 📜 License
Muhammad Ahsan — free to use, modify, and share.

---
