var React = require('react');
var ReactBootstrap = require('reactBootstrap');

var security = require('../security');

var LogIn = React.createClass({
	
	getInitialState(){
		return {
			userName: '',			
			password: ''
		};
	},

	handleChange(e){
		switch (e.target.id) {
			case 'loginUserName':
				this.setState({userName: e.target.value});
				break;
			case 'loginPassword':
				this.setState({
					password: e.target.value
				});
			break;
		}
	},

	login() {
		security.login(this.state);
	},

	render() {
		var Panel = ReactBootstrap.Panel;
		var Input = ReactBootstrap.Input;
		var Button = ReactBootstrap.Button;

		return(
			<Panel header='Login' bsStyle='primary'>
				<form className='form-horizontal'>
					<Input type='text' id='loginUserName' value={this.state.userName} onChange={this.handleChange} label='Username' labelClassName='col-xs-2' wrapperClassName='col-xs-12' />
					<Input type='password' id='loginPassword' value={this.state.password} onChange={this.handleChange} label='Password' labelClassName='col-xs-2' wrapperClassName='col-xs-12' />
					<Button onClick={this.login} bsStyle='primary'>Login</Button>
				</form>
			</Panel>
		);
	}
});

module.exports = LogIn;