class_name State
extends Node
var signal_connections : Array[SignalConnection] = []
func state_all_signals_disconnect():
	for i in len(signal_connections):
		state_signal_disconnect(signal_connections[i])
func state_signal_disconnect(signal_connection : SignalConnection):
	if Gl.safe_disconnect(signal_connection.signal_,signal_connection.callable):
		signal_connections.erase(signal_connection)
func state_signal_connect(signal_ : Signal,callable : Callable):
	if Gl.safe_connect(signal_,callable):
		var signal_connection = SignalConnection.new(signal_,callable) as SignalConnection
		signal_connections.append(signal_connection)
		return signal_connection
func enter():
	pass
func process(delta):
	pass
func physics(delta):
	pass
func exit():
	pass
