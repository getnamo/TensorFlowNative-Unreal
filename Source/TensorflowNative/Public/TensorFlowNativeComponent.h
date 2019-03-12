#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "TensorFlowWrapper.h"
#include "TensorFlowNativeComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class TENSORFLOWNATIVE_API UTensorFlowNativeComponent : public UActorComponent
{
	GENERATED_BODY()

public:	

	//UFUNCTION(BlueprintCallable, Category = TensorflowNative)


	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = TensorflowNativeProperties)
	FString DefaultDirectory;

	// Sets default values for this component's properties
	UTensorFlowNativeComponent();

	// Called every frame
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

protected:
	// Called when the game starts
	virtual void BeginPlay() override;	
	TSharedPtr<FTensorflowUtility> TFUtil;
};
