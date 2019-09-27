// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "TensorflowLib.h"
#include "TensorflowCApi.h"

#define LOCTEXT_NAMESPACE "FTensorflowNativeModule"

void FTensorflowLibModule::StartupModule()
{
	// This code will execute after your module is loaded into memory; the exact timing is specified in the .uplugin file per-module

	UE_LOG(LogTemp, Log, TEXT("Loaded TensorflowLib, version %s"), *FString(TF_Version()));
}

void FTensorflowLibModule::ShutdownModule()
{
	// This function may be called during shutdown to clean up your module.  For modules that support dynamic reloading,
	// we call this function before unloading the module.
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FTensorflowLibModule, TensorflowLib)