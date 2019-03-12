#include "TensorFlowWrapper.h"
#include "Runtime/Core/Public/HAL/PlatformFilemanager.h"

bool FTensorflowUtility::ReadBytesFromFile(const FString& Directory, const FString& FileName, TArray<uint8>& OutBytes)
{
	// Get absolute file path
	FString AbsoluteFilePath = Directory + "/" + FileName;

	// Allow overwriting or file doesn't already exist
	return FFileHelper::LoadFileToArray(OutBytes, *AbsoluteFilePath);
}

TF_Buffer* FTensorflowUtility::ReadBufferFromFile(const FString& FilePath)
{
	TArray<uint8> OutBytes;
	bool bLoaded = FFileHelper::LoadFileToArray(OutBytes, *FilePath);
	if (!bLoaded)
	{
		return nullptr;
	}

	TF_Buffer* Buffer = TF_NewBuffer();
	Buffer->data = OutBytes.GetData();
	Buffer->length = OutBytes.Num();
	//Buffer->data_deallocator, relevant here?

	return Buffer;
}

