using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;

namespace UnityEditor.Rendering.Universal.ShaderGUI
{
#if UNITY_PIPELINE_URP
    internal class UnityBabylonGUI
    {
        [Flags]
        internal enum BabylonExpandable
        {
            /// <summary>
            /// Use this for surface options foldout.
            /// </summary>
            SurfaceOptions = 1 << 0,

            /// <summary>
            /// Use this for surface input foldout.
            /// </summary>
            SurfaceInputs = 1 << 1,

            /// <summary>
            /// Use this for advanced foldout.
            /// </summary>
            Advanced = 1 << 2,

            /// <summary>
            /// Use this for additional details foldout.
            /// </summary>
            Details = 1 << 3,

            /// <summary>
            /// Use this for babylon properties foldout.
            /// </summary>
            Babylon = 1 << 4,

            /// <summary>
            /// Use this for custom properties foldout.
            /// </summary>
            Custom = 1 << 5
        }

        internal static class Styles
        {
            public static readonly GUIContent babylonInputs = EditorGUIUtility.TrTextContent("Babylon Inputs", "These settings define the babylon shader properties on the surface.");
            public static readonly GUIContent customInputs = EditorGUIUtility.TrTextContent("Custom Inputs", "These settings define the custom shader properties on the surface.");
            public static readonly GUIContent ambientText = EditorGUIUtility.TrTextContent("Ambient Color", "Ambient Color");
            public static readonly GUIContent lightingText = EditorGUIUtility.TrTextContent("Enable Lighting", "Enable Material Lighting");
            public static readonly GUIContent unlitText = EditorGUIUtility.TrTextContent("Render Unlit Material", "Render Unlit Material");
            public static readonly GUIContent freezeText = EditorGUIUtility.TrTextContent("Freeze Shader Material", "Freeze Shader Material");
            public static readonly GUIContent wireframeText = EditorGUIUtility.TrTextContent("Use Wireframe Material", "Use Wireframe Material");
            public static readonly GUIContent maxLightCountText = EditorGUIUtility.TrTextContent("Simultaneous Lights", "Simultaneous Lights");
            public static readonly GUIContent backFaceCullingText = EditorGUIUtility.TrTextContent("Set Back Face Culling", "Set Back Face Culling");
            public static readonly GUIContent lightmapIntensityText = EditorGUIUtility.TrTextContent("Lightmap Level", "Lightmap Level");
            public static readonly GUIContent normalmapStrengthText = EditorGUIUtility.TrTextContent("Normal Map Scale", "Normal Map Scale");
            public static readonly GUIContent directIntensityText = EditorGUIUtility.TrTextContent("Direct Intensity", "Direct Intensity");
            public static readonly GUIContent specularIntensityText = EditorGUIUtility.TrTextContent("Specular Intensity", "Specular Intensity");
            public static readonly GUIContent emissiveIntensityText = EditorGUIUtility.TrTextContent("Emissive Intensity", "Emissive Intensity");
            public static readonly GUIContent environmentIntensityText = EditorGUIUtility.TrTextContent("Environment Intensity", "Environment Intensity");
            public static readonly GUIContent clearCoatIntensityText = EditorGUIUtility.TrTextContent("Clear Coat Intensity", "Clear Coat Intensity");
            public static readonly GUIContent specularBaseText = EditorGUIUtility.TrTextContent("Specular Base", "Base Specular Map Color Multiplier");
            public static readonly GUIContent reflectColorText = EditorGUIUtility.TrTextContent("Reflect Color", "Reflect Color");
            public static readonly GUIContent cubeText = EditorGUIUtility.TrTextContent("Reflection Cubemap", "Reflection Cubemap");
            public static readonly GUIContent boxSizeText = EditorGUIUtility.TrTextContent("Box Size", "Box Size");
            public static readonly GUIContent boxOffsetText = EditorGUIUtility.TrTextContent("Box Offset", "Box Offset");
            public static readonly GUIContent indexOfRefractionText = EditorGUIUtility.TrTextContent("Index Of Refraction", "Index Of Refraction");
            public static readonly GUIContent detailBlendLevelText = EditorGUIUtility.TrTextContent("Detail Blend Level", "Detail Blend Level");
            public static readonly GUIContent detailRoughnessLevelText = EditorGUIUtility.TrTextContent("Detail Roughness Level", "Detail Roughness Level");
        }

        public struct BabylonProperties
        {
            public MaterialProperty ambient;
            public MaterialProperty lighting;
            public MaterialProperty unlit;
            public MaterialProperty freeze;
            public MaterialProperty wireframe;
            public MaterialProperty backFaceCulling;
            public MaterialProperty maxLightCount;
            public MaterialProperty lightmapIntensity;
            public MaterialProperty normalmapStrength;
            public MaterialProperty directIntensity;
            public MaterialProperty specularIntensity;
            public MaterialProperty emissiveIntensity;
            public MaterialProperty environmentIntensity;
            public MaterialProperty clearCoatIntensity;
            public MaterialProperty specularBaseColor;
            public MaterialProperty reflectColor;
            public MaterialProperty cube;
            public MaterialProperty boxSize;
            public MaterialProperty boxOffset;
            public MaterialProperty indexOfRefraction;
            public MaterialProperty detailBlendLevel;
            public MaterialProperty detailRoughnessLevel;
            public List<MaterialProperty> customProperties;

            public BabylonProperties(MaterialProperty[] properties)
            {
                ambient = BaseShaderGUI.FindProperty("_AmbientColor", properties, false);
                lighting = BaseShaderGUI.FindProperty("_EnableLighting", properties, false);
                unlit = BaseShaderGUI.FindProperty("_UnlitMaterial", properties, false);
                freeze = BaseShaderGUI.FindProperty("_FreezeMaterial", properties, false);
                wireframe = BaseShaderGUI.FindProperty("_UseWireframe", properties, false);
                backFaceCulling = BaseShaderGUI.FindProperty("_BackFaceCulling", properties, false);
                maxLightCount = BaseShaderGUI.FindProperty("_MaxLightCount", properties, false);
                lightmapIntensity = BaseShaderGUI.FindProperty("_LightmapIntensity", properties, false);
                directIntensity = BaseShaderGUI.FindProperty("_DirectIntensity", properties, false);
                emissiveIntensity = BaseShaderGUI.FindProperty("_EmissiveIntensity", properties, false);
                specularIntensity = BaseShaderGUI.FindProperty("_SpecularIntensity", properties, false);
                environmentIntensity = BaseShaderGUI.FindProperty("_EnvironmentIntensity", properties, false);
                clearCoatIntensity = BaseShaderGUI.FindProperty("_ClearCoatIntensity", properties, false);
                normalmapStrength = BaseShaderGUI.FindProperty("_NormalMapStrength", properties, false);
                specularBaseColor = BaseShaderGUI.FindProperty("_SpecBaseColor", properties, false);
                reflectColor = BaseShaderGUI.FindProperty("_ReflectColor", properties, false);
                cube = BaseShaderGUI.FindProperty("_Cube", properties, false);
                boxSize = BaseShaderGUI.FindProperty("_BoxSize", properties, false);
                boxOffset = BaseShaderGUI.FindProperty("_BoxOffset", properties, false);
                indexOfRefraction = BaseShaderGUI.FindProperty("_IndexOfRefraction", properties, false);
                detailBlendLevel = BaseShaderGUI.FindProperty("_DetailBlendLevel", properties, false);
                detailRoughnessLevel = BaseShaderGUI.FindProperty("_DetailRoughnessLevel", properties, false);
                // ..
                // Find Custom Properties
                // ..
                string AddtionalReservedPropertyNames = "";
                customProperties = new List<MaterialProperty>();                
                if (properties != null && properties.Length > 0) {
                    foreach (MaterialProperty prop in properties) {
                        if ((prop.flags & (MaterialProperty.PropFlags.HideInInspector | MaterialProperty.PropFlags.PerRendererData)) != 0) continue;
                        if (CanvasToolsStatics.SystemPredefinedPropertyNames.IndexOf(prop.name, StringComparison.OrdinalIgnoreCase) == -1) {
                            if (AddtionalReservedPropertyNames.IndexOf(prop.name, StringComparison.OrdinalIgnoreCase) == -1) {
                                customProperties.Add(prop);
                            }
                        }
                    }
                }
            }
        }

        public static void DoBabylonArea(BabylonProperties properties, MaterialEditor materialEditor)
        {
            if (properties.lighting != null)
                materialEditor.ShaderProperty(properties.lighting, Styles.lightingText);
            if (properties.ambient != null)
                materialEditor.ShaderProperty(properties.ambient, Styles.ambientText);
            if (properties.lightmapIntensity != null)
                materialEditor.ShaderProperty(properties.lightmapIntensity, Styles.lightmapIntensityText);
            if (properties.directIntensity != null)
                materialEditor.ShaderProperty(properties.directIntensity, Styles.directIntensityText);
            if (properties.emissiveIntensity != null)
                materialEditor.ShaderProperty(properties.emissiveIntensity, Styles.emissiveIntensityText);
            if (properties.specularIntensity != null)
                materialEditor.ShaderProperty(properties.specularIntensity, Styles.specularIntensityText);
            if (properties.environmentIntensity != null)
                materialEditor.ShaderProperty(properties.environmentIntensity, Styles.environmentIntensityText);
            if (properties.clearCoatIntensity != null)
                materialEditor.ShaderProperty(properties.clearCoatIntensity, Styles.clearCoatIntensityText);
            if (properties.normalmapStrength != null)
                materialEditor.ShaderProperty(properties.normalmapStrength, Styles.normalmapStrengthText);
            if (properties.maxLightCount != null)
                materialEditor.ShaderProperty(properties.maxLightCount, Styles.maxLightCountText);
            if (properties.backFaceCulling != null)
                materialEditor.ShaderProperty(properties.backFaceCulling, Styles.backFaceCullingText);
            if (properties.freeze != null)
                materialEditor.ShaderProperty(properties.freeze, Styles.freezeText);
            if (properties.unlit != null)
                materialEditor.ShaderProperty(properties.unlit, Styles.unlitText);
            if (properties.wireframe != null)
                materialEditor.ShaderProperty(properties.wireframe, Styles.wireframeText);
            if (properties.reflectColor != null)
                materialEditor.ShaderProperty(properties.reflectColor, Styles.reflectColorText);
            if (properties.cube != null)
                materialEditor.ShaderProperty(properties.cube, Styles.cubeText);
            if (properties.boxSize != null)
                materialEditor.ShaderProperty(properties.boxSize, Styles.boxSizeText);
            if (properties.boxOffset != null)
                materialEditor.ShaderProperty(properties.boxOffset, Styles.boxOffsetText);
            if (properties.indexOfRefraction != null)
                materialEditor.ShaderProperty(properties.indexOfRefraction, Styles.indexOfRefractionText);
            if (properties.detailBlendLevel != null)
                materialEditor.ShaderProperty(properties.detailBlendLevel, Styles.detailBlendLevelText);
            if (properties.detailRoughnessLevel != null)
                materialEditor.ShaderProperty(properties.detailRoughnessLevel, Styles.detailRoughnessLevelText);
        }

        public static void DoCustomArea(BabylonProperties properties, MaterialEditor materialEditor)
        {
            if (properties.customProperties != null && properties.customProperties.Count > 0) {
                for (var i = 0; i < properties.customProperties.Count; i++) {
                    if ((properties.customProperties[i].flags & (MaterialProperty.PropFlags.HideInInspector | MaterialProperty.PropFlags.PerRendererData)) != 0) continue;
                    float h = materialEditor.GetPropertyHeight(properties.customProperties[i], properties.customProperties[i].displayName);
                    Rect r = EditorGUILayout.GetControlRect(true, h, EditorStyles.layerMaskField);
                    materialEditor.ShaderProperty(r, properties.customProperties[i], properties.customProperties[i].displayName);
                }
            }
        }
    }

    internal class UnityLitDetailGUI
    {
        internal static class Styles
        {
            public static readonly GUIContent detailInputs = EditorGUIUtility.TrTextContent("Detail Inputs",
                "These settings define the surface details by tiling and overlaying additional maps on the surface.");

            public static readonly GUIContent detailMaskText = EditorGUIUtility.TrTextContent("Mask",
                "Select a mask for the Detail map. The mask uses the alpha channel of the selected texture. The Tiling and Offset settings have no effect on the mask.");

            public static readonly GUIContent detailAlbedoMapText = EditorGUIUtility.TrTextContent("Base Map",
                "Select the surface detail texture.The alpha of your texture determines surface hue and intensity.");

            public static readonly GUIContent detailNormalMapText = EditorGUIUtility.TrTextContent("Normal Map",
                "Designates a Normal Map to create the illusion of bumps and dents in the details of this Material's surface.");

            public static readonly GUIContent detailAlbedoMapScaleInfo = EditorGUIUtility.TrTextContent("Setting the scaling factor to a value other than 1 results in a less performant shader variant.");
            public static readonly GUIContent detailAlbedoMapFormatError = EditorGUIUtility.TrTextContent("This texture is not in linear space.");
        }

        public struct LitProperties
        {
            public MaterialProperty detailMask;
            public MaterialProperty detailAlbedoMapScale;
            public MaterialProperty detailAlbedoMap;
            public MaterialProperty detailNormalMapScale;
            public MaterialProperty detailNormalMap;

            public LitProperties(MaterialProperty[] properties)
            {
                detailMask = BaseShaderGUI.FindProperty("_DetailMask", properties, false);
                detailAlbedoMapScale = BaseShaderGUI.FindProperty("_DetailAlbedoMapScale", properties, false);
                detailAlbedoMap = BaseShaderGUI.FindProperty("_DetailAlbedoMap", properties, false);
                detailNormalMapScale = BaseShaderGUI.FindProperty("_DetailNormalMapScale", properties, false);
                detailNormalMap = BaseShaderGUI.FindProperty("_DetailNormalMap", properties, false);
            }
        }

        public static void DoDetailArea(LitProperties properties, MaterialEditor materialEditor)
        {
            materialEditor.TexturePropertySingleLine(Styles.detailMaskText, properties.detailMask);
            materialEditor.TexturePropertySingleLine(Styles.detailAlbedoMapText, properties.detailAlbedoMap,
                properties.detailAlbedoMap.textureValue != null ? properties.detailAlbedoMapScale : null);
            if (properties.detailAlbedoMapScale.floatValue != 1.0f)
            {
                EditorGUILayout.HelpBox(Styles.detailAlbedoMapScaleInfo.text, MessageType.Info, true);
            }
            var detailAlbedoTexture = properties.detailAlbedoMap.textureValue as Texture2D;
            if (detailAlbedoTexture != null && GraphicsFormatUtility.IsSRGBFormat(detailAlbedoTexture.graphicsFormat))
            {
                EditorGUILayout.HelpBox(Styles.detailAlbedoMapFormatError.text, MessageType.Warning, true);
            }
            materialEditor.TexturePropertySingleLine(Styles.detailNormalMapText, properties.detailNormalMap,
                properties.detailNormalMap.textureValue != null ? properties.detailNormalMapScale : null);
            materialEditor.TextureScaleOffsetProperty(properties.detailAlbedoMap);
        }

        public static void SetMaterialKeywords(Material material)
        {
            if (material.HasProperty("_DetailAlbedoMap") && material.HasProperty("_DetailNormalMap") && material.HasProperty("_DetailAlbedoMapScale"))
            {
                bool isScaled = material.GetFloat("_DetailAlbedoMapScale") != 1.0f;
                bool hasDetailMap = material.GetTexture("_DetailAlbedoMap") || material.GetTexture("_DetailNormalMap");
                CoreUtils.SetKeyword(material, "_DETAIL_MULX2", !isScaled && hasDetailMap);
                CoreUtils.SetKeyword(material, "_DETAIL_SCALED", isScaled && hasDetailMap);
            }
        }
    }

    internal class UnityLitShader : BaseShaderGUI
    {
        static readonly string[] workflowModeNames = Enum.GetNames(typeof(LitGUI.WorkflowMode));

        private LitGUI.LitProperties litProperties;
        private UnityLitDetailGUI.LitProperties litDetailProperties;
        private UnityBabylonGUI.BabylonProperties babylonProperties;

        public override void FillAdditionalFoldouts(MaterialHeaderScopeList materialScopesList)
        {
            materialScopesList.RegisterHeaderScope(UnityLitDetailGUI.Styles.detailInputs, UnityBabylonGUI.BabylonExpandable.Details, _ => UnityLitDetailGUI.DoDetailArea(litDetailProperties, materialEditor));
            materialScopesList.RegisterHeaderScope(UnityBabylonGUI.Styles.babylonInputs, UnityBabylonGUI.BabylonExpandable.Babylon, _ => UnityBabylonGUI.DoBabylonArea(babylonProperties, materialEditor));
            materialScopesList.RegisterHeaderScope(UnityBabylonGUI.Styles.customInputs, UnityBabylonGUI.BabylonExpandable.Custom, _ => UnityBabylonGUI.DoCustomArea(babylonProperties, materialEditor));
        }

        // collect properties from the material properties
        public override void FindProperties(MaterialProperty[] properties)
        {
            base.FindProperties(properties);
            litProperties = new LitGUI.LitProperties(properties);
            litDetailProperties = new UnityLitDetailGUI.LitProperties(properties);
            babylonProperties = new UnityBabylonGUI.BabylonProperties(properties);
        }

        // material changed check
        public override void ValidateMaterial(Material material)
        {
            SetMaterialKeywords(material, LitGUI.SetMaterialKeywords, UnityLitDetailGUI.SetMaterialKeywords);
        }

        // material main surface options
        public override void DrawSurfaceOptions(Material material)
        {
            // Use default labelWidth
            EditorGUIUtility.labelWidth = 0f;

            if (litProperties.workflowMode != null)
                DoPopup(LitGUI.Styles.workflowModeText, litProperties.workflowMode, workflowModeNames);

            base.DrawSurfaceOptions(material);
        }

        // material main surface inputs
        public override void DrawSurfaceInputs(Material material)
        {
            base.DrawSurfaceInputs(material);
            LitGUI.Inputs(litProperties, materialEditor, material);
            DrawEmissionProperties(material, true);
            DrawTileOffset(materialEditor, baseMapProp);
        }

        // material main advanced options
        public override void DrawAdvancedOptions(Material material)
        {
            if (litProperties.reflections != null && litProperties.highlights != null)
            {
                materialEditor.ShaderProperty(litProperties.highlights, LitGUI.Styles.highlightsText);
                materialEditor.ShaderProperty(litProperties.reflections, LitGUI.Styles.reflectionsText);
            }

            base.DrawAdvancedOptions(material);
        }

        public override void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            // _Emission property is lost after assigning Standard shader to the material
            // thus transfer it before assigning the new shader
            if (material.HasProperty("_Emission"))
            {
                material.SetColor("_EmissionColor", material.GetColor("_Emission"));
            }

            base.AssignNewShaderToMaterial(material, oldShader, newShader);

            if (oldShader == null || !oldShader.name.Contains("Legacy Shaders/"))
            {
                SetupMaterialBlendMode(material);
                return;
            }

            SurfaceType surfaceType = SurfaceType.Opaque;
            BlendMode blendMode = BlendMode.Alpha;
            if (oldShader.name.Contains("/Transparent/Cutout/"))
            {
                surfaceType = SurfaceType.Opaque;
                material.SetFloat("_AlphaClip", 1);
            }
            else if (oldShader.name.Contains("/Transparent/"))
            {
                // NOTE: legacy shaders did not provide physically based transparency
                // therefore Fade mode
                surfaceType = SurfaceType.Transparent;
                blendMode = BlendMode.Alpha;
            }
            material.SetFloat("_Blend", (float)blendMode);

            material.SetFloat("_Surface", (float)surfaceType);
            if (surfaceType == SurfaceType.Opaque)
            {
                material.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
            }
            else
            {
                material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            }

            if (oldShader.name.Equals("Standard (Specular setup)"))
            {
                material.SetFloat("_WorkflowMode", (float)LitGUI.WorkflowMode.Specular);
                Texture texture = material.GetTexture("_SpecGlossMap");
                if (texture != null)
                    material.SetTexture("_MetallicSpecGlossMap", texture);
            }
            else
            {
                material.SetFloat("_WorkflowMode", (float)LitGUI.WorkflowMode.Metallic);
                Texture texture = material.GetTexture("_MetallicGlossMap");
                if (texture != null)
                    material.SetTexture("_MetallicSpecGlossMap", texture);
            }
        }
    }

    internal class UnityUnlitShader : BaseShaderGUI
    {
        private UnityBabylonGUI.BabylonProperties babylonProperties;

        public override void FillAdditionalFoldouts(MaterialHeaderScopeList materialScopesList)
        {
            materialScopesList.RegisterHeaderScope(UnityBabylonGUI.Styles.babylonInputs, UnityBabylonGUI.BabylonExpandable.Babylon, _ => UnityBabylonGUI.DoBabylonArea(babylonProperties, materialEditor));
            materialScopesList.RegisterHeaderScope(UnityBabylonGUI.Styles.customInputs, UnityBabylonGUI.BabylonExpandable.Custom, _ => UnityBabylonGUI.DoCustomArea(babylonProperties, materialEditor));
        }

        // collect properties from the material properties
        public override void FindProperties(MaterialProperty[] properties)
        {
            base.FindProperties(properties);
            babylonProperties = new UnityBabylonGUI.BabylonProperties(properties);
        }

        // material changed check
        public override void ValidateMaterial(Material material)
        {
            SetMaterialKeywords(material);
        }

        // material main surface options
        public override void DrawSurfaceOptions(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            // Use default labelWidth
            EditorGUIUtility.labelWidth = 0f;

            base.DrawSurfaceOptions(material);
        }

        // material main surface inputs
        public override void DrawSurfaceInputs(Material material)
        {
            base.DrawSurfaceInputs(material);
            DrawTileOffset(materialEditor, baseMapProp);
        }

        public override void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            // _Emission property is lost after assigning Standard shader to the material
            // thus transfer it before assigning the new shader
            if (material.HasProperty("_Emission"))
            {
                material.SetColor("_EmissionColor", material.GetColor("_Emission"));
            }

            base.AssignNewShaderToMaterial(material, oldShader, newShader);

            if (oldShader == null || !oldShader.name.Contains("Legacy Shaders/"))
            {
                SetupMaterialBlendMode(material);
                return;
            }

            SurfaceType surfaceType = SurfaceType.Opaque;
            BlendMode blendMode = BlendMode.Alpha;
            if (oldShader.name.Contains("/Transparent/Cutout/"))
            {
                surfaceType = SurfaceType.Opaque;
                material.SetFloat("_AlphaClip", 1);
            }
            else if (oldShader.name.Contains("/Transparent/"))
            {
                // NOTE: legacy shaders did not provide physically based transparency
                // therefore Fade mode
                surfaceType = SurfaceType.Transparent;
                blendMode = BlendMode.Alpha;
            }
            material.SetFloat("_Blend", (float)blendMode);

            material.SetFloat("_Surface", (float)surfaceType);
            if (surfaceType == SurfaceType.Opaque)
            {
                material.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
            }
            else
            {
                material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            }
        }
    }
#endif    
}
