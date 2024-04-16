import 'package:flutter/material.dart';
import 'package:flutter_application_1/Config/DefaultVars.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Add Users to Group',
      theme: ThemeData.dark(),
      home: AddUsersToGroupWidget(),
    );
  }
}

class AddUsersToGroupWidget extends StatefulWidget {
  @override
  _AddUsersToGroupWidgetState createState() => _AddUsersToGroupWidgetState();
}

class _AddUsersToGroupWidgetState extends State<AddUsersToGroupWidget> {
  List<Map<String, dynamic>> _groups = [];
  List<Map<String, dynamic>> _users = [];
  int i =0;
  String _selectedGroupId = "SELECT a ITEM";
  List<String> _selectedUserIds = [];

  @override
  void initState() {
    super.initState();
    _fetchGroups();
    _fetchUsers();
  }

  Future<void> _fetchGroups() async {
    final response =
        await http.get(Uri.parse(DefaultVars.baseurl+'/Groups/list'));
    if (response.statusCode == 200) {
      final List<dynamic> groupsJson = jsonDecode(response.body);
      setState(() {
        _groups = groupsJson
            .map((group) => Map<String, dynamic>.from(group))
            .toList();
            _selectedGroupId = _groups.map((e) => e['id'] as String).first;
      });
    } else {
      throw Exception('Failed to load groups');
    }
  }

  Future<void> _fetchUsers() async {
    final response =
        await http.get(Uri.parse(DefaultVars.baseurl+'/Users/list'));

    if (response.statusCode == 200) {
      final List<dynamic> usersJson = jsonDecode(response.body);
      setState(() {
        _users =
            usersJson.map((user) => Map<String, dynamic>.from(user)).toList();
      });
    } else {
      throw Exception('Failed to load users');
    }
  }

  Future<void> _addUsersToGroup() async {
    final url = Uri.parse(
        DefaultVars.baseurl+'/Groups/GroupUserAdd'); // Replace 'https://example.com/addUsersToGroup' with your actual endpoint
    final body = jsonEncode({
      'groupId': _selectedGroupId,
      'userIds': _selectedUserIds,
    });

    final response = await http.put(
      url,
      headers: {'Content-Type': 'application/json'},
      body: body,
    );

    if (response.statusCode == 200) {
      // Successfully added users to the group
      AlertDialog(title: Text('Done!'));
    } else {
      throw Exception('Failed to add users to group');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Add Users to Group'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text('Select a group:'),
            DropdownButtonFormField<String>(
              value: _selectedGroupId,
              items: _groups.map((group) {
                    return DropdownMenuItem<String>(
                      value: group['id'],
                      child: Text(group['name'],style: TextStyle(color: Colors.white70),),
                    );
                  })
                  .toList(), // Convert to a set to remove duplicate values, then convert back to a list
              onChanged: (value) {
                setState(() {
                  _selectedGroupId = value.toString();
                });
              },
            ),
            SizedBox(height: 20),
            Text('Select users to add:'),
            Expanded(
              child: ListView.builder(
                itemCount: _users.length,
                itemBuilder: (context, index) {
                  final user = _users[index];
                  return CheckboxListTile(
                    title: Text('${user['name']} ${user['surname']}'),
                    value: _selectedUserIds.contains(user['id']),
                    onChanged: (value) {
                      setState(() {
                        if (value != null && value) {
                          _selectedUserIds.add(user['id']);
                        } else {
                          _selectedUserIds.remove(user['id']);
                        }
                      });
                    },
                  );
                },
              ),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                if (_selectedGroupId != null && _selectedUserIds.isNotEmpty) {
                  _addUsersToGroup();
                }
              },
              child: Text('Add Users to Group'),
            ),
          ],
        ),
      ),
    );
  }
}
