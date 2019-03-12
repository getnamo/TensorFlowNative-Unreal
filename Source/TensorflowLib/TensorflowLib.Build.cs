// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class TensorflowLib : ModuleRules
{
	private string ThirdPartyPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../ThirdParty/")); }
	}

	private string BinariesPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../Binaries/")); }
	}

	public string GetUProjectPath()
	{
		return Path.Combine(ModuleDirectory, "../../../..");
	}

	private int HashFile(string FilePath)
	{
		string DLLString = File.ReadAllText(FilePath);
		return DLLString.GetHashCode() + DLLString.Length;  //ensure both hash and file lengths match
	}

	private void CopyToProjectBinaries(string Filepath, ReadOnlyTargetRules Target)
	{
		//System.Console.WriteLine("uprojectpath is: " + Path.GetFullPath(GetUProjectPath()));

		string BinariesDir = Path.Combine(GetUProjectPath(), "Binaries", Target.Platform.ToString());
		string Filename = Path.GetFileName(Filepath);

		//convert relative path 
		string FullBinariesDir = Path.GetFullPath(BinariesDir);

		if (!Directory.Exists(FullBinariesDir))
		{
			Directory.CreateDirectory(FullBinariesDir);
		}

		string FullExistingPath = Path.Combine(FullBinariesDir, Filename);
		bool ValidFile = false;

		//File exists, check if they're the same
		if (File.Exists(FullExistingPath))
		{
			int ExistingFileHash = HashFile(FullExistingPath);
			int TargetFileHash = HashFile(Filepath);
			ValidFile = ExistingFileHash == TargetFileHash;
			if (!ValidFile)
			{
				System.Console.WriteLine("TensorFlowNative plugin: outdated dll detected.");
			}
		}

		//No valid existing file found, copy new dll
		if (!ValidFile)
		{
			System.Console.WriteLine("TensorFlowNative plugin: Copied from " + Filepath + ", to " + Path.Combine(FullBinariesDir, Filename));
			File.Copy(Filepath, Path.Combine(FullBinariesDir, Filename), true);
		}
	}

	public bool LoadLib(ReadOnlyTargetRules Target)
	{
		bool isLibrarySupported = false;

		if ((Target.Platform == UnrealTargetPlatform.Win64))
		{
			isLibrarySupported = true;

			string PlatformString = (Target.Platform == UnrealTargetPlatform.Win64) ? "Win64" : "Win32";
			string TensorflowLibPlatformPath = Path.Combine(ThirdPartyPath, "Tensorflow/Lib", PlatformString);
			string TensorflowLibPath = Path.GetFullPath(Path.Combine(TensorflowLibPlatformPath, "tensorflow.lib"));
			string TensorflowDLLPath = Path.GetFullPath(Path.Combine(TensorflowLibPlatformPath, "tensorflow.dll"));

			PublicAdditionalLibraries.Add(TensorflowLibPath);
			PublicDelayLoadDLLs.Add(TensorflowDLLPath);
			RuntimeDependencies.Add(TensorflowDLLPath);
			CopyToProjectBinaries(TensorflowDLLPath, Target);
		}

		return isLibrarySupported;
	}

	public TensorflowLib(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
		);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				Path.Combine(ThirdPartyPath, "Tensorflow/Include")
				// ... add other private include paths required here ...
			}
		);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
		);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
		);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
		);

		LoadLib(Target);
	}
}
