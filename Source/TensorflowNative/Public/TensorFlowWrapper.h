#pragma once
#include "TensorflowCApi.h"

class TENSORFLOWNATIVE_API FTensorflowUtility
{
public:

	static bool ReadBytesFromFile(const FString& Directory, const FString& FileName, TArray<uint8>& OutBytes);

	static TF_Buffer* ReadBufferFromFile(const FString& FilePath);
};