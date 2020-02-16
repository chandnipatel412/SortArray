import React, { Component } from 'react';
import axios from 'axios';

export class SortArray extends Component {
	constructor(props) {
		super(props);
		this.onChangeInputType = this.onChangeInputType.bind(this);
		this.onChangeInput = this.onChangeInput.bind(this);
		this.state = {
			inputType: 'Numbers',
			input: '',
			steps: [],
			loading: true,
			failed: false,
			error: '',
			valid: true
		}
	}

	onChangeInputType(e) {
		this.setState({
			inputType: e.target.value
		});
	}

	onChangeInput(e) {
		this.setState({
			input: e.target.value
		});
	}

	handleClick = (e) => {
		e.preventDefault();
		this.populateSteps();
	}

	populateSteps() {
		axios.get("api/SortArray/GetSortArray?inputType=" + this.state.inputType + "&input=" + this.state.input).then(result => {
			const response = result.data;
			this.setState({ steps: response, loading: false, failed: false, error: '' });
		}).catch(ex => {
			this.setState({ steps: [], loading: false, failed: true, error: ex.response.data });
		});

	}

	renderAllSteps(steps) {
		return (
			<div>
				<p>Sorting steps are as follows:</p>
				<table className="table table-striped">
					<thead>
						<tr>
							<th>Step#</th>
							<th>Step Description</th>
						</tr>
					</thead>
					<tbody>
						{
							steps.map(step => (
								<tr key={step.stepNumber}>
									<td>{step.stepNumber}</td>
									<td>{step.step}</td>
								</tr>
							))
						}
					</tbody>
				</table>
			</div>
		)
	}

	render() {
		let content = this.state.loading ? (
			<p></p>
		) : (
				this.state.failed ? (
					<div className="alert alert-danger">
						<em>{this.state.error.split("\n").map((i, key) => {
							return <div key={key}>{i}</div>;
						})}</em>
					</div>
				) : (
						this.renderAllSteps(this.state.steps)
					)
			)

		return (
			<div className="pt-4">
				<div className="sort-form">
					<form>
						<div className="form-group">
							<label>Input Type:</label>
							<select className="form-control" value={this.state.inputType} onChange={this.onChangeInputType}>
								<option value="Numbers">Numbers</option>
								<option value="Strings">Strings</option>
							</select>
						</div>
						<div className="form-group">
							<label>Input:</label>
							<input type="text" className="form-control" value={this.state.input} onChange={this.onChangeInput}></input>
						</div>
					</form>
					<div className="form-group">
						<button onClick={(e) => this.handleClick(e)} className="btn btn-primary">Submit</button>
					</div>
				</div>
				{content}
			</div>
		);
	}
}