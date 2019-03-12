#include "TensorFlowNativeComponent.h"


// Sets default values for this component's properties
UTensorFlowNativeComponent::UTensorFlowNativeComponent()
{
	PrimaryComponentTick.bCanEverTick = false;
	DefaultDirectory = FPaths::ProjectContentDir() + "/TensorflowData";

	TFUtil = MakeShareable(new FTensorflowUtility);
}

// Called when the game starts
void UTensorFlowNativeComponent::BeginPlay()
{
	Super::BeginPlay();
}


// Called every frame
void UTensorFlowNativeComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	// ...
}

