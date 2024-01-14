class_name SignalConnection
extends Resource
func _init(_signal_ : Signal = Signal() ,_callable : Callable = Callable() ):
	signal_ = _signal_
	callable = _callable
var signal_ = null 
var callable = null 
